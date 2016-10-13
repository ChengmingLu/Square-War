using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {
    public Vector3 playerBasePosition = new Vector3(370f, -370f, 0);
    public Vector3 enemyBasePosition = new Vector3(-370f, 370f, 0);
    public int money;
    public int totalAmmo;
	// Use this for initialization
	void Start () {
        money = 0;
        if (gameObject.GetComponent<Player>()) {
            gameObject.transform.position = playerBasePosition;
        } else {
            gameObject.transform.position = enemyBasePosition;
        }
        gameObject.GetComponent<Movable>().stablizePosition();
	    
	}
	
	// Update is called once per frame
	void Update () {

	}



}
