using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    
    public GameObject shot;
    public float range;
    public Level[] levels;
    public int mana;

    GameObject enemySpawner;
    GameObject target;
    MeshRenderer meshRender;

    bool canShoot;
    int MaxHP;
    int HP;

    float shotPS;
    int level;

    // Use this for initialization
    void Start() {
        meshRender = GetComponent<MeshRenderer>();
        MaxHP = levels[0].HP;
        HP = MaxHP;
        shotPS = levels[0].shotPS;
        canShoot = true;
        level = 1;
        meshRender.material.color = levels[0].tint;
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
                        target = child.Find("Enemy").gameObject;
                    } else if (Vector3.Distance(transform.position, child.position) <
                               Vector3.Distance(transform.position, target.transform.position)) {
                        target = child.Find("Enemy").gameObject;
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
            script.Init(target, levels[level - 1].damage, transform);
        }

		if (HP < 0) {
			Destroy(gameObject);
            DataMan.mana += mana;
            TowerSpawner.grid[(int)transform.position.x + TowerSpawner.width / 2, (int)transform.position.z + TowerSpawner.height / 2] = false;
		}
    }

	public void Damage(int damage) {
		HP -= damage;
	}

	public IEnumerator ShootTick() {
        canShoot = false;
        yield return new WaitForSeconds(1 / shotPS); // wait
        canShoot = true;
	}

    public void Upgrade() {
        if (levels.Length > level) {
            if (DataMan.coins >= levels[level].Cost) {
                level++;
                MaxHP = levels[level - 1].HP;
                shotPS = levels[level - 1].shotPS;
                DataMan.coins -= levels[level - 1].Cost;
                meshRender.material.color = levels[level - 1].tint;
                HP = MaxHP;
            }
        }
    }
}

[System.Serializable]
public struct Level {
    public int HP;
    public int damage;
    public float shotPS;
    public Color tint;
    public int Cost;
    //public int Range;
    //public int Damage;
}
