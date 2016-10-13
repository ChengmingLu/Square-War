using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {
    public float speed;
    public Vector3 destination;
    private Vector3 moveThreshold = new Vector3(0.1f, 0.1f, 0);
    public bool needToMove = false;
    public bool reachedDestination = false;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if ((Mathf.Abs(destination.x - gameObject.transform.position.x) >= moveThreshold.x ||
            Mathf.Abs(destination.y - gameObject.transform.position.y) >= moveThreshold.y) && needToMove) {
            //Debug.Log(mousPos + " is mouse position:moving");
            //Debug.Log("in movable: " + destination + " is object position:moving");
            //gameObject.transform.Translate(((destination - 
            //gameObject.transform.position) * speed * Time.deltaTime));
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(destination.x -
                gameObject.transform.position.x, destination.y -
                gameObject.transform.position.y).normalized * speed;
            reachedDestination = false;
        } else {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            //needToMove = false;
            reachedDestination = true;
        }
	}

    public void stablizePosition() {
        destination = gameObject.transform.position;
    }
}
