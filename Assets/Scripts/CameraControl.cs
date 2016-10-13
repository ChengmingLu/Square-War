using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    float cameraThreshold = 20f;
    float cameraBoundary = 400f;
    float cameraFoV = 300f;
    float maxCameraFoV = 550f;
    float minCameraFoV = 200f;
    float scrollSensitivity = 50f;
    Camera cam;
    //Camera cam;
    float speed = 200f;
    void Start () {
        cam = GameObject.FindObjectOfType<Camera>();
	}
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(Input.mousePosition.x - Screen.width) <= cameraThreshold
            && transform.position.x <= cameraBoundary) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);  
        }
        if (Input.mousePosition.x <= cameraThreshold
            && transform.position.x >= -cameraBoundary) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);  
        }
        if (Mathf.Abs(Input.mousePosition.y - Screen.height) <= cameraThreshold
            && transform.position.y <= cameraBoundary) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);  
        }
        if (Input.mousePosition.y <= cameraThreshold
            && transform.position.y >= -cameraBoundary) {
            transform.Translate(Vector3.down * speed * Time.deltaTime);  
        }
        cameraFoV -= Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
        cameraFoV = Mathf.Clamp(cameraFoV, minCameraFoV, maxCameraFoV);
        cam.orthographicSize = cameraFoV;
	}
}
