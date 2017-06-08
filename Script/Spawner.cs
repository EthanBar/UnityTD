﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    bool canSpawn;
    public float spawnInter;

	// Use this for initialization
	void Start () {
        canSpawn = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			//Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) {
				//Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.name == "Plane") {
					Debug.Log("It's working!");
                    GameObject newEnemy = Instantiate(enemy);
                    newEnemy.transform.SetParent(gameObject.transform);
                    Vector3 pos = hitInfo.point;
                    pos.y += 0.25f;
                    newEnemy.transform.position = pos;
				} else {
					Debug.Log("nopz");
				}
			} else {
				Debug.Log("No hit");
			}
			//Debug.Log("Mouse is down");
		}
		if (canSpawn) {
            StartCoroutine(SpawnEnemy());
            //print("spawn");
        }
	}

	public IEnumerator SpawnEnemy() {
		canSpawn = false;
		yield return new WaitForSeconds(spawnInter); // wait
		canSpawn = true;
	}
}