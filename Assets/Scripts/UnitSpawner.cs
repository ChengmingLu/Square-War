using UnityEngine;
using System.Collections;

public class UnitSpawner : MonoBehaviour {
    public int wifooCost;
    public int hoosbandCost;
    public GameObject wifooPrefab;
    public GameObject hoosbandPrefab;
    public int maxWifooCount;
    public int maxHoosbandCount;
    public Vector3[] playerWifooPosition;
    public Vector3[] playerHoosbandPosition;
    private GameObject[] playerWifooObjects;
    private GameObject[] playerHoosbandObjects;


	// Use this for initialization
	void Start () {
        //spawn something first
        if (gameObject.transform.parent.gameObject.GetComponent<Player>()) {
            //playerWifooObjects = GameObject.FindGameObjectsWithTag("PlayerWifoo");
            //playerHoosbandObjects = GameObject.FindGameObjectsWithTag("PlayerHoosband");
            for (int i = 0; i < maxHoosbandCount; i++) {
                Instantiate(hoosbandPrefab, playerHoosbandPosition[i], Quaternion.identity);
            }
            for (int i = 0; i < maxWifooCount; i++) {
                Instantiate(wifooPrefab, playerWifooPosition[i], Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.parent.gameObject.GetComponent<Player>()) {
            playerWifooObjects = GameObject.FindGameObjectsWithTag("PlayerWifoo");
            playerHoosbandObjects = GameObject.FindGameObjectsWithTag("PlayerHoosband");
            if (playerWifooObjects.Length < maxWifooCount) {
                for (int i = playerWifooObjects.Length; i < maxWifooCount; i++) {
                    if (gameObject.transform.parent.gameObject.GetComponent<Base>().money >= wifooCost) {
                        gameObject.transform.parent.gameObject.GetComponent<Base>().money -= wifooCost;
                        Instantiate(wifooPrefab, playerWifooPosition[i], Quaternion.identity);
                        gameObject.transform.parent.gameObject.GetComponentInChildren<MoneyDisplay>().updateDisplay();
                    } else {
                        Debug.Log("insufficient money");
                    }
                }
            }
            if (playerHoosbandObjects.Length < maxWifooCount) {
                for (int i = playerHoosbandObjects.Length; i < maxHoosbandCount; i++) {
                    if (gameObject.transform.parent.gameObject.GetComponent<Base>().money >= hoosbandCost) {
                        gameObject.transform.parent.gameObject.GetComponent<Base>().money -= hoosbandCost;
                        Instantiate(hoosbandPrefab, playerHoosbandPosition[i], Quaternion.identity);
                        gameObject.transform.parent.gameObject.GetComponentInChildren<MoneyDisplay>().updateDisplay();
                    } else {
                        Debug.Log("not enough money");
                    }
                }
            }
        }
	}
}
