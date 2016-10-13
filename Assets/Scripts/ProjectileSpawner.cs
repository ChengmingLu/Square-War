using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour {
    public GameObject projectile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.parent.gameObject.GetComponent<Hoosband>().ammo <= 0) {
            //maybe return to base? but not sure though
        }
	}

    public void fireShots(Transform targeTransform) {//yetz
        projectile.GetComponent<Movable>().destination = targeTransform.position;
        projectile.GetComponent<Movable>().needToMove = true;
        Instantiate(projectile, gameObject.transform.parent.gameObject.transform.position, Quaternion.identity);
        gameObject.transform.parent.gameObject.GetComponent<Hoosband>().ammo -= 1;
    }
}
