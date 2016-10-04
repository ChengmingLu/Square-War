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
}
