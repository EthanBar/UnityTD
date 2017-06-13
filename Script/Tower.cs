using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    
    public GameObject shot;
    GameObject enemySpawner;

    GameObject target;

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
        // Check if we have a target
        if (target != null) {
            transform.LookAt(target.transform); // Look at target
            transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y, 0f));
        } else {
            // Get new target if needed
			foreach (Transform child in enemySpawner.transform) {
                if (target == null) {
                    target = child.gameObject;
				} else if (Vector3.Distance(transform.position, child.position) <
                           Vector3.Distance(transform.position, target.transform.position)) {
                    target = child.gameObject;
				}
			}
        }
        if (canShoot && target != null) {
            // Target found, will shoot
            StartCoroutine(ShootTick()); // Reset shot counter
            GameObject shotp = Instantiate(shot, transform.position, Quaternion.identity);
            Shot script = shotp.GetComponent<Shot>();
            script.Init(target);
        }
    }

	public IEnumerator ShootTick() {
        canShoot = false;
        yield return new WaitForSeconds(shootTime); // wait
        canShoot = true;
	}
}
