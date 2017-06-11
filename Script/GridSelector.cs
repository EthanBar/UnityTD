using UnityEngine;

public class GridSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hitInfo;
		Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
		transform.position = new Vector3(Mathf.Round(hitInfo.point.x), 0.01f, Mathf.Round(hitInfo.point.z));
	}
}
