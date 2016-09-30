using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    float CameraThreshold = 2f;
    float CameraBoundary = 5f;
    //Camera cam;
    float speed = 2f;
    void Start () {
        //cam = GameObject.FindObjectOfType<Camera>();
	}
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs(Input.mousePosition.x - Screen.width) <= CameraThreshold
            && transform.position.x <= CameraBoundary) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);  
        }

        if (Input.mousePosition.x <= CameraThreshold
            && transform.position.x >= -CameraBoundary) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);  
        }

        if (Mathf.Abs(Input.mousePosition.y - Screen.height) <= CameraThreshold
            && transform.position.y <= CameraBoundary) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);  
        }

        if (Input.mousePosition.y <= CameraThreshold
            && transform.position.y >= -CameraBoundary) {
            transform.Translate(Vector3.down * speed * Time.deltaTime);  
        }
	}
}
