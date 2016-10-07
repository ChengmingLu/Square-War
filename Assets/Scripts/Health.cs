using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public float health;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
            Debug.Log(gameObject + " is destroyed with health below 0");
            Destroy(gameObject);
        }
	}
}
