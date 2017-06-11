using UnityEngine;

public class TowerSpawner : MonoBehaviour
{

	public GameObject Tower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			RaycastHit hitInfo;
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) {
				if (hitInfo.transform.gameObject.name == "Ground") {
					GameObject newTower = Instantiate(Tower);
					newTower.transform.SetParent(gameObject.transform);
					Vector3 pos = hitInfo.point;
					pos.y += 0.5f;
					newTower.transform.position = pos;
				}
			}
		}
	}
}
