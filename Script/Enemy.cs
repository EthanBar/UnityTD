using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public int Hp;

	private NavMeshAgent agent;
	GameObject towerSpawner;

	void Start() {
		towerSpawner = GameObject.Find("Tower Spawner");
		agent = GetComponent<NavMeshAgent>();
	}

	void Update () {
		GameObject toShoot = null;
		foreach (Transform child in towerSpawner.transform) {
			if (toShoot == null) {
				toShoot = child.gameObject;
			}
			else if (Vector3.Distance(transform.position, child.position) <
			         Vector3.Distance(transform.position, toShoot.transform.position)) {
				toShoot = child.gameObject;
			}
		}
//		agent.velocity += new Vector3(0, 0, 1);
		if (toShoot != null) agent.destination = toShoot.transform.position;
		if (Hp < 0) {
            Destroy(gameObject);
        }
	}

	public void Damage(int damage) {
		Hp -= damage;
	}
}
