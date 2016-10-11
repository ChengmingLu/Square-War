using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Wifoo : MonoBehaviour {
    public Vector3 playerWifooPosition = new Vector3(-591f, -320f, 0);
    public Vector3 enemyWifooPosition = new Vector3(-595f, -314f, 0);
    public bool canCollect;
    private bool needToReturnBase;
    public int resourceCollected;
    private GameObject baseObject;
    private GameObject toggle;
    private bool justCollided;
    private float wifooStuckInBaseThreshold = 0.1f;
    // Use this for initialization
    void Start() {
        toggle = GameObject.FindGameObjectWithTag("Toggle");
        justCollided = false;
        needToReturnBase = false;
        canCollect = false;
        resourceCollected = 0;
        if (gameObject.GetComponent<Player>()) {
            //Debug.Log("This wifoo is player");
            gameObject.transform.position = playerWifooPosition;
        } else {
            //Debug.Log("This wifoo is enemy");
            gameObject.transform.position = enemyWifooPosition;
        }
        //Debug.Log("trying to find base");
        if (gameObject.GetComponent<Player>()) {
            baseObject = GameObject.FindGameObjectWithTag("PlayerBase");
        } else {
            baseObject = GameObject.FindGameObjectWithTag("EnemyBase");
        }
        //Debug.Log("What we found was " + baseObject);
        gameObject.GetComponent<Movable>().stablizePosition();
    }
    // Update is called once per frame
    void Update() {
        if (resourceCollected <= 0) {
            canCollect = true;
            needToReturnBase = false;
        } else {
            canCollect = false;
            needToReturnBase = true;
        }

        if (Vector3.Distance(gameObject.transform.position, baseObject.transform.position)
            <= wifooStuckInBaseThreshold) {
            Debug.Log("wifoo is in the base, need to stick wifoo to resource, turning autocollect off");
            gameObject.GetComponent<Movable>().destination = getnearestResource().transform.position;
            toggle.GetComponent<Toggle>().isOn = false;
        }

        if (autoCollect() && !justCollided && needToReturnBase) {
            //Debug.Log("need to return to base from switch of auto collect");
            gameObject.GetComponent<Movable>().destination = baseObject.transform.position;
            gameObject.GetComponent<Movable>().needToMove = true;
        } else if (autoCollect() && !justCollided) {
            //Debug.Log("need to get more resources from auto collect switch");
            gameObject.GetComponent<Movable>().destination = getnearestResource().transform.position;
            gameObject.GetComponent<Movable>().needToMove = true;
        } else if (autoCollect() && justCollided) {
            //Debug.Log("update overridden by trigger collider");
        } else {
            //Debug.Log("This is something else");
        }
        justCollided = false;
    }
    void OnTriggerEnter2D(Collider2D collider) {
        justCollided = true;
        GameObject colliderObject = collider.gameObject;
        if (colliderObject.GetComponent<Resource>() && canCollect) {
            resourceCollected += 5;
            Debug.Log("wifoo's resource load: " + resourceCollected + "and is returning to base");
            gameObject.GetComponent<Movable>().destination = baseObject.transform.position;
            if (!autoCollect()) {
                gameObject.GetComponent<Movable>().stablizePosition();
            }
        }
        if (colliderObject.GetComponent<Base>()) {
            Debug.Log("wifoo returned to its corresponding base and is out for resources");
            if (resourceCollected > 0) {
                colliderObject.GetComponent<Base>().money += resourceCollected;
                resourceCollected = 0;
            }
            gameObject.GetComponent<Movable>().destination = getnearestResource().transform.position;
            if (!autoCollect()) {
                gameObject.GetComponent<Movable>().stablizePosition();
            }
        }
    }

    GameObject getnearestResource() {
        GameObject[] allResources = GameObject.FindGameObjectsWithTag("Resource");
        //Debug.Log(allResources.Length + " resources found");
        float shortestDist = Mathf.Infinity;
        int nearestResourceIndex = 0;
        for (int count = 0; count < allResources.Length; count += 1) {
            float tempDist = Vector3.Distance(allResources[count].transform.position, gameObject.transform.position);
            if (tempDist <= shortestDist) {
                shortestDist = tempDist;
                nearestResourceIndex = count;
            }
        }
        return allResources[nearestResourceIndex];
    }

    public bool autoCollect() {
        if (toggle.GetComponent<Toggle>().isOn) {
            return true;
        } else {
            return false;
        }
    }
}

