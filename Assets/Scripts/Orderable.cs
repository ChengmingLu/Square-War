//TODO
//Add tempObject and be able to swap when new object is selected
//
using UnityEngine;
using System.Collections;

public class Orderable : MonoBehaviour {
    //public GameObject basePrefab;
    public static GameObject selectedUnit;
    //private bool selected;
    private Vector3 mousPos, objPos2D;

    //private GameObject tempObject;
	// Use this for initialization
	void Start () {
        //selected = false;
        //tempObject = gameObject;
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)) {
            //Debug.Log("Right click detected, selected unit is " + selectedUnit);
            if (selectedUnit != null) {
                gameObject.GetComponent<Movable>().needToMove = true;
                mousPos = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                mousPos.z = 0;
                //Debug.Log("Mouse position is " + mousPos);
                selectedUnit.GetComponent<Movable>().destination = mousPos;
                //Debug.Log("Position for " + gameObject + " is set to " + 
                    //gameObject.GetComponent<Movable>().destination);         
            }
        }
	}
    void OnMouseDown() {
        //tempObject = gameObject;
        selectedUnit = gameObject;
        Debug.Log("Selected unit assigned to " + selectedUnit);
    }
}