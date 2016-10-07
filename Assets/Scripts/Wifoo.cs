using UnityEngine;
using System.Collections;

public class Wifoo : MonoBehaviour {
    public Vector3 playerWifooPosition = new Vector3(2f, -3.6f, 0);
    public Vector3 enemyWifooPosition = new Vector3(-2f, 3.6f, 0);
    public bool canCollect;
    private bool needToReturnBase;
    private int resourceCollected;
    private GameObject baseObject;
    // Use this for initialization
    void Start() {
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
        gameObject.GetComponent<Movable>().destination = gameObject.transform.position;
        gameObject.GetComponent<Movable>().needToMove = false;
        //Debug.Log("trying to find base");
        if (gameObject.GetComponent<Player>()) {
            baseObject = GameObject.FindGameObjectWithTag("PlayerBase");
        } else {
            baseObject = GameObject.FindGameObjectWithTag("EnemyBase");
        }
        //Debug.Log("What we found was " + baseObject);
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
        if (needToReturnBase) {
            gameObject.GetComponent<Movable>().destination = baseObject.transform.position;
        } else {
            if (GameObject.FindGameObjectWithTag("Resource") != null) {
                GameObject resourceObject = GameObject.FindGameObjectWithTag("Resource");
                gameObject.GetComponent<Movable>().destination = resourceObject.transform.position;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider) {
        GameObject tempObject = collider.gameObject;
        if (tempObject.GetComponent<Resource>() && canCollect) {
            resourceCollected += 5;
            Debug.Log("wifoo's resource load: " + resourceCollected);
        }
        if (tempObject.tag == "PlayerBase" && gameObject.GetComponent<Player>()) {
            Debug.Log("player wifoo returning to player base");
            if (!canCollect) {
                tempObject.GetComponent<Base>().money = resourceCollected;
                resourceCollected = 0;
            }
        } else if (tempObject.tag == "EnemyBase" && gameObject.GetComponent<Enemy>()) {
            Debug.Log("enemy wifoo returning to enemy base");
            if (!canCollect) {
                tempObject.GetComponent<Base>().money = resourceCollected;
                resourceCollected = 0;
            }
        }
    }
}

