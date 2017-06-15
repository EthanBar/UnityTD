using UnityEngine;

public class TowerSpawner : MonoBehaviour {

	public GameObject Tower;

    public bool[,] grid;

	// Use this for initialization
	void Start () {
        grid = new bool[30, 30];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			RaycastHit hitInfo;
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) {
                if (hitInfo.transform.gameObject.name == "Grid Selector" && !grid[Mathf.RoundToInt(hitInfo.point.x + 15), Mathf.RoundToInt(hitInfo.point.z + 15)]) {
                    grid[Mathf.RoundToInt(hitInfo.point.x + 15), Mathf.RoundToInt(hitInfo.point.z + 15)] = true;
					GameObject newTower = Instantiate(Tower);
					newTower.transform.SetParent(gameObject.transform);
					newTower.transform.position = new Vector3(Mathf.Round(hitInfo.point.x), 0.4f, Mathf.Round(hitInfo.point.z));
				} else if (hitInfo.transform.gameObject.tag == "Tower") {
                    // Upgrade
                    Tower script = hitInfo.transform.gameObject.GetComponent<Tower>();
                    script.shootTime -= 0.1f;
                    print(script.shootTime);
                }
			}
		}
	}
}
