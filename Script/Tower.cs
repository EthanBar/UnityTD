using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    
    public GameObject shot;
    GameObject enemySpawner;

    bool canShoot;
    System.Timers.Timer timer;
    public float shootTime;

    // Use this for initialization
    void Start() {
        canShoot = true;
        enemySpawner = GameObject.Find("Enemy Spawner");
    }

    // Update is called once per frame
    void Update() {
        if (canShoot) {
            GameObject toShoot = null;
            foreach (Transform child in enemySpawner.transform) {
                if (toShoot == null) {
                    toShoot = child.gameObject;
                } else if (Vector3.Distance(transform.position, child.position) <
                           Vector3.Distance(transform.position, toShoot.transform.position)) {
                    toShoot = child.gameObject;
                }
			}
            StartCoroutine(ShootTick());
            GameObject shotp = Instantiate(shot, transform.position, Quaternion.identity);
            Shot script = shotp.GetComponent<Shot>();
            script.Init(toShoot);
        }
    }

	public IEnumerator ShootTick() {
        canShoot = false;
        yield return new WaitForSeconds(shootTime); // wait
        canShoot = true;
	}
}
