using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public int Hp;
	GameObject towerSpawner;
	private Rigidbody rb;
	public float maxSpeed;
	public float acceleration;

	void Start() {
		towerSpawner = GameObject.Find("Tower Spawner");
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		GameObject toAttack = null;
		foreach (Transform child in towerSpawner.transform) {
			if (toAttack == null) {
				toAttack = child.gameObject;
			}
			else if (Vector3.Distance(transform.position, child.position) <
			         Vector3.Distance(transform.position, toAttack.transform.position)) {
				toAttack = child.gameObject;
			}
		}
		if (toAttack != null) rb.AddForce((toAttack.transform.position - transform.position).normalized * acceleration, ForceMode.VelocityChange);
//		agent.velocity += new Vector3(0, 0, 1);
		if(rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
	
		if (Hp < 0) {
            Destroy(gameObject);
        }
	}

	public void Damage(int damage) {
		Hp -= damage;
	}
}
