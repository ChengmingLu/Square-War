﻿using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {
    public int fullHealth = 100;
    public Vector3 playerBasePosition = new Vector3(3.5f, -3.5f, 0);
    public Vector3 enemyBasePosition = new Vector3(-3.5f, 3.5f, 0);
	// Use this for initialization
	void Start () {
        if (gameObject.GetComponent<Player>()) {
            gameObject.transform.position = playerBasePosition;
        } else {
            gameObject.transform.position = enemyBasePosition;
        }
        gameObject.GetComponent<Movable>().destination = gameObject.transform.position;
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (fullHealth <= 0) {
            Destroy(gameObject);
            gameObject.GetComponent<Player>().lose = true;
        }
	}



}
