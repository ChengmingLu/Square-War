using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    float CameraThreshold = 2f;
    Camera cam;
    int Horizontal = 1;
    int Vertical = 1;
    float speed = 2f;
	// Use this for initialization
	void Start () {
        cam = GameObject.FindObjectOfType<Camera>();
	}
	// Update is called once per frame
	void Update () {
        Debug.Log("Mouse:" +Input.mousePosition+ ";pos:"+transform.position+";Cam:" +
            cam.orthographicSize + ";screen"+Screen.width + " " + Screen.height);

        if (transform.position.x > 0 && transform.position.x < Screen.width
            && transform.position.y > 0 && transform.position.y < Screen.height) {

        }
                    if (Mathf.Abs(Input.mousePosition.x - Screen.width) <= CameraThreshold) {
                transform.Translate(Vector3.right * speed * Time.deltaTime);  
            }
            if (Input.mousePosition.x <= CameraThreshold) {
                transform.Translate(Vector3.left * speed * Time.deltaTime);  
            }
            if (Mathf.Abs(Input.mousePosition.y - Screen.height) <= CameraThreshold) {
                transform.Translate(Vector3.up * speed * Time.deltaTime);  
            }
            if (Input.mousePosition.y <= CameraThreshold) {
                transform.Translate(Vector3.down * speed * Time.deltaTime);  
            }

        //float y = Vertical * Input.GetAxis("Mouse Y");
        
	}
}
