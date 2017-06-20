using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    bool _canSpawn;
    public float SpawnInter;

	// Use this for initialization
	void Start () {
        _canSpawn = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)) {
			//Debug.Log("Mouse is down");

            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) {
//                if (hitInfo.transform.gameObject.name == "Grid Selector") {
                GameObject newEnemy = Instantiate(ButtonSpawner.activeEnemy);
                    newEnemy.transform.SetParent(gameObject.transform);
                    Vector3 pos = hitInfo.point;
                    pos.y = 0.25f;
                    newEnemy.transform.position = pos;
//				}
			}
		}
		if (_canSpawn) {
            StartCoroutine(SpawnEnemy());
            //print("spawn");
        }
	}

	public IEnumerator SpawnEnemy() {
		_canSpawn = false;
		yield return new WaitForSeconds(SpawnInter); // wait
		_canSpawn = true;
	}
}
