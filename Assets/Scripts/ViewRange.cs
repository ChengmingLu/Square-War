using UnityEngine;
using System.Collections;

public class ViewRange : MonoBehaviour {
    public float viewRange;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<CircleCollider2D>().radius = viewRange;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject colliderGameObject = collider.gameObject;
        if (colliderGameObject.GetComponent<Enemy>() && gameObject.transform.parent.gameObject.GetComponent<Player>()) {
            Debug.Log("Enemydetected: " + colliderGameObject + " is in range of " + gameObject.transform.parent.gameObject);
            gameObject.transform.parent.gameObject.GetComponentInChildren<ProjectileSpawner>().fireShots(colliderGameObject.transform);
        } else if (colliderGameObject.GetComponent<Player>() && gameObject.transform.parent.gameObject.GetComponent<Enemy>()) {
            Debug.Log("Playerdetected: " + colliderGameObject + " is in range of " + gameObject.transform.parent.gameObject);
            gameObject.transform.parent.gameObject.GetComponentInChildren<ProjectileSpawner>().fireShots(colliderGameObject.transform);

        }
    }
}
