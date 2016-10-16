using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour {
    public GameObject projectile;
    public int damage;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void fireShots(Transform targeTransform) {//yetz
        projectile.GetComponent<Movable>().destination = targeTransform.position;
        projectile.GetComponent<Movable>().needToMove = true;
        projectile.GetComponent<Projectile>().damage = damage;
        if (gameObject.transform.parent.gameObject.GetComponent<Base>()) {
            if (gameObject.transform.parent.gameObject.GetComponent<Base>().totalAmmo > 0) {
                gameObject.transform.parent.gameObject.GetComponent<Base>().totalAmmo -= 1;
                Instantiate(projectile, gameObject.transform.parent.gameObject.transform.position, Quaternion.identity);
            } else {
                Debug.Log("Base has no ammo left");
            }
            gameObject.transform.parent.gameObject.GetComponentInChildren<AmmoDisplay>().updateDisplay();
        } else if (gameObject.transform.parent.gameObject.GetComponent<Hoosband>()) {
            if (gameObject.transform.parent.gameObject.GetComponent<Hoosband>().ammo > 0) {
                gameObject.transform.parent.gameObject.GetComponent<Hoosband>().ammo -= 1;
                Instantiate(projectile, gameObject.transform.parent.gameObject.transform.position, Quaternion.identity);
            } else {
                Debug.Log("Hoosband has no ammo");
            }
            
        } else {
            Debug.Log("cannot fire shots notz, this is something else");
        }
    }
}
