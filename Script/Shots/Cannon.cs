using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    Shot shot;

	// Use this for initialization
	void Start () {
        shot = GetComponent<Shot>();
	}
	
	// Update is called once per frame
	void Update () {
        if (shot.target == null) Destroy(gameObject); // If target is not found, disappear
        if (shot.target != null) {
            transform.position = Vector3.MoveTowards(transform.position, shot.target.transform.position, shot.speed);
        }
	}

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject == shot.target) {
            hit.gameObject.GetComponent<Enemy>().Damage(shot.dmg);
            Destroy(gameObject);
        }
    }
}
