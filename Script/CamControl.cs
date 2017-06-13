using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

    public float moveSens;
    public float zoomSens;
    public float maxZoom;
    public float minZoom;

    Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)) {
            transform.position += new Vector3(moveSens, 0, -moveSens);
        }
		if (Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(-moveSens, 0, moveSens);
		}
		if (Input.GetKey(KeyCode.S)) {
            transform.position += new Vector3(moveSens, 0, moveSens);
		}
		if (Input.GetKey(KeyCode.W)) {
            transform.position += new Vector3(-moveSens, 0, -moveSens);
		}

        cam.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * zoomSens;
        if (cam.orthographicSize > maxZoom) cam.orthographicSize = maxZoom;
        if (cam.orthographicSize < minZoom) cam.orthographicSize = minZoom;
	}
}
