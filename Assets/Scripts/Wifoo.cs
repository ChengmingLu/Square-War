using UnityEngine;
using System.Collections;

public class Wifoo : MonoBehaviour {
    public int fullHealth = 10;
    public Vector3 playerWifooPosition = new Vector3(2f, -3.6f, 0);
    public Vector3 enemyWifooPosition = new Vector3(-2f, 3.6f, 0);
	// Use this for initialization
	void Start () {
        if (gameObject.GetComponent<Player>()) {
            Debug.Log("This wifoo is player");
            gameObject.transform.position = playerWifooPosition;
        } else {
            Debug.Log("This wifoo is enemy");
            gameObject.transform.position = enemyWifooPosition;
        }
        gameObject.GetComponent<Movable>().destination = gameObject.transform.position;
        gameObject.GetComponent<Movable>().needToMove = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (fullHealth <= 0) {
            Destroy(gameObject);
        }
	}
}
