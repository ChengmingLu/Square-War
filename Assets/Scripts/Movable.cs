using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {
    public float speed;
    public Vector3 destination;
    private Vector3 moveThreshold = new Vector3(0.1f, 0.1f, 0);
	// Use this for initialization
	void Start () {
        destination = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Mathf.Abs(destination.x - gameObject.transform.position.x) >= moveThreshold.x || 
            Mathf.Abs(destination.y - gameObject.transform.position.y) >= moveThreshold.y) {
            //Debug.Log(mousPos + " is mouse position:moving");
            Debug.Log("in movable: " + destination + " is object position:moving");
            gameObject.transform.Translate(((destination - 
                gameObject.transform.position) * speed * Time.deltaTime));
        }
	}
}
