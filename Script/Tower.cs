using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    
    public GameObject shot;

    public float shootTime;
    public float range;

    GameObject enemySpawner;
    GameObject target;

    bool canShoot;
    int MaxHP;
    int HP;

    //[System.Serializable]
    public Level[] levels;
    int level;

    // Use this for initialization
    void Start() {
        MaxHP = levels[0].HP;
        HP = MaxHP;
        canShoot = true;
        level = 1;
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
            if (enemySpawner.transform.childCount > 0) {
                foreach (Transform child in enemySpawner.transform) {
                    if (target == null) {
                        target = child.gameObject;
                    } else if (Vector3.Distance(transform.position, child.position) <
                               Vector3.Distance(transform.position, target.transform.position)) {
                        target = child.gameObject;
                    }
                }
                if (Vector3.Distance(transform.position, target.transform.position) > range) target = null;
            }
        }
        if (canShoot && target != null) {
            // Target found, will shoot
            StartCoroutine(ShootTick()); // Reset shot counter
            GameObject shotp = Instantiate(shot, transform.position, Quaternion.identity);
            Shot script = shotp.GetComponent<Shot>();
            script.Init(target);
        }

		if (HP < 0) {
			Destroy(gameObject);
		}
    }

	public void Damage(int damage) {
		HP -= damage;
	}

	public IEnumerator ShootTick() {
        canShoot = false;
        yield return new WaitForSeconds(shootTime); // wait
        canShoot = true;
	}

    public void Upgrade() {
        if (levels.Length > level) {
            level++;
            if (ScoreManager.points >= levels[level - 1].Cost) {
                MaxHP = levels[level - 1].HP;
                shootTime = levels[level - 1].Speed;
                ScoreManager.points -= levels[level - 1].Cost;
            }
        }
    }
}

[System.Serializable]
public struct Level {
    public int HP;
    public int Cost;
    public int Speed;
    public int Range;
    public int Damage;
}
