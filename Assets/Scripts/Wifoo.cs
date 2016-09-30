using UnityEngine;
using System.Collections;

public class Wifoo : MonoBehaviour {

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
