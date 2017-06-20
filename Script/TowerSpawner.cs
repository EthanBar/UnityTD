using UnityEngine;

public class TowerSpawner : MonoBehaviour {


    public Transform ground;
    public Towers[] towers;
    public int startCoins;

    public static bool[,] grid;
    public static int width, height;

    // Use this for initialization
    void Start () {
        DataMan.coins += startCoins;
        width = (int)(ground.lossyScale.x * 10);
        height = (int)(ground.lossyScale.z * 10);
        grid = new bool[width, height];
	}

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift)) DataMan.coins += 100;
        if (Input.GetMouseButtonUp(1)) {
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit) {
                if (hitInfo.transform.gameObject.name == "Grid Selector" && !grid[Mathf.RoundToInt(hitInfo.point.x + width / 2), Mathf.RoundToInt(hitInfo.point.z + height / 2)]) {
                    GameObject tower = ButtonSpawner.activeTower;
                    if (DataMan.coins >= tower.GetComponent<Tower>().levels[0].Cost) {
                        DataMan.coins -= tower.GetComponent<Tower>().levels[0].Cost;
                        grid[Mathf.RoundToInt(hitInfo.point.x + width / 2), Mathf.RoundToInt(hitInfo.point.z + height / 2)] = true;
                        GameObject newTower = Instantiate(tower);
                        newTower.transform.SetParent(transform);
                        newTower.transform.position = new Vector3(Mathf.Round(hitInfo.point.x), 0.4f, Mathf.Round(hitInfo.point.z));
                    }
                } else if (hitInfo.transform.gameObject.tag == "Tower") {
                    // Upgrade
                    Tower script = hitInfo.transform.gameObject.GetComponent<Tower>();
                    script.Upgrade();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab)) {
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit) {
                GameObject spell = ButtonSpawner.activeSpell;
                if (DataMan.mana >= spell.GetComponent<Spell>().cost) {
                    DataMan.mana -= spell.GetComponent<Spell>().cost;
                    GameObject newSpell = Instantiate(spell);
                    //newSpell.transform.SetParent(transform);
                    newSpell.transform.position = new Vector3(hitInfo.point.x, 0.01f, hitInfo.point.z);
                }
            }
        }
	}
}

[System.Serializable]
public struct Towers {
    public GameObject tower;
    public KeyCode key;
    public int cost;
}
