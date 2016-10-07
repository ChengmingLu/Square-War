using UnityEngine;
using System.Collections;

public class Hoosband : MonoBehaviour {
    public Vector3 playerHoosbandPosition = new Vector3(2f, -3f, 0);
    public Vector3 enemyHoosbandPosition = new Vector3(-2f, 3f, 0);
	// Use this for initialization
	void Start () {
        if (gameObject.GetComponent<Player>()) {
            //Debug.Log("This hoosband is player");
            gameObject.transform.position = playerHoosbandPosition;
        } else {
            //Debug.Log("This hoosband is enemy");
            gameObject.transform.position = enemyHoosbandPosition;
        }
        gameObject.GetComponent<Movable>().destination = gameObject.transform.position;
        gameObject.GetComponent<Movable>().needToMove = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
