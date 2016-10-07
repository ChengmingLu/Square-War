using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {
    public int resourceCount = 100;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (resourceCount <= 0) {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.GetComponent<Wifoo>() && 
            collider.gameObject.GetComponent<Wifoo>().canCollect) {
            //Debug.Log("Wifoo touched me!!!!!");
            resourceCount -= 5;
            Debug.Log(resourceCount + "remaining");
        } 
    }
}
