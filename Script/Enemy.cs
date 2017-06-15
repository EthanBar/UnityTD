using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public int Hp;
    public int dmg;
    public float atkSpd;
	GameObject towerSpawner;
	Rigidbody rb;
	public float maxSpeed;
    public float acceleration;
    public int pnts;

    GameObject target;
    bool canAtk;


	void Start() {
		towerSpawner = GameObject.Find("Tower Spawner");
		rb = GetComponent<Rigidbody>();
        canAtk = true;
	}

	void FixedUpdate () {
        if (Hp < 0) {
            ScoreManager.points += pnts;
            Destroy(gameObject);
        }

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

        if (target != null && canAtk) {
            StartCoroutine(Attack());
            Tower script = target.gameObject.GetComponent<Tower>();
            script.Damage(dmg);
        }
	}

    IEnumerator Attack() {
        canAtk = false;
        yield return new WaitForSeconds(atkSpd);
        canAtk = true;
    }
    

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Tower") {
            target = collision.gameObject;
		}
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Tower") {
            target = null;
        }
    }

    public void Damage(int damage) {
		Hp -= damage;
	}
}
