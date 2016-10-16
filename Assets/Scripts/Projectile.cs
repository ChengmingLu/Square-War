using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public int damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<Movable>().reachedDestination) {
            Debug.Log("shit I have arrived!");
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject colliderGameObject = collider.gameObject;
        if (colliderGameObject.GetComponent<Health>() && (colliderGameObject.GetComponent<Enemy>() && gameObject.GetComponent<Player>()
            || colliderGameObject.GetComponent<Player>() && gameObject.GetComponent<Enemy>())) {
            colliderGameObject.GetComponent<Health>().health -= damage;
            Debug.Log("shit I hit something : " + colliderGameObject);
            Destroy(gameObject);
        }
    }   
}
