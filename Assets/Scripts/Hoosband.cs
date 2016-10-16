using UnityEngine;
using System.Collections;

public class Hoosband : MonoBehaviour {
    //public Vector3 playerHoosbandPosition = new Vector3(243f, -316f, 0);
    //public Vector3 enemyHoosbandPosition = new Vector3(-243f, 316f, 0);
    public int ammo;
    public int ammoCapacity = 2;
    private GameObject baseObject;
    private GameObject viewRangeChild;
	// Use this for initialization
	void Start () {
        if (gameObject.GetComponent<Player>()) {
            baseObject = GameObject.FindGameObjectWithTag("PlayerBase");
            //gameObject.transform.position = playerHoosbandPosition;
        } else {
            baseObject = GameObject.FindGameObjectWithTag("EnemyBase");
            //gameObject.transform.position = enemyHoosbandPosition;
        }
        gameObject.GetComponent<Movable>().stablizePosition();
        viewRangeChild = gameObject.transform.Find("ViewRangeCollider").gameObject;
        Debug.Log("found child: " + viewRangeChild);
	}
	
	// Update is called once per frame
	void Update () {
        if (ammo <= 0) {
            viewRangeChild.GetComponent<CircleCollider2D>().enabled = false;
            //Debug.Log("disabled");
        } else {
            viewRangeChild.GetComponent<CircleCollider2D>().enabled = true;
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject colliderGameObject = collider.gameObject;
        if (colliderGameObject == baseObject) {
            gameObject.GetComponent<Movable>().stablizePosition();
            if (baseObject.GetComponent<Base>().totalAmmo > 0) {
                baseObject.GetComponent<Base>().totalAmmo -= ( ammoCapacity - ammo );
                ammo = ammoCapacity;
                baseObject.GetComponentInChildren<AmmoDisplay>().updateDisplay();
            }
        }
    }
}
