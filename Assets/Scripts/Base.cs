using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {
    public int health = 100;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseDown() {
        Debug.Log("Click detected on " + gameObject);  
    }


}
