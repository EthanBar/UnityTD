using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    GameObject target;
    public float speed;
    public int dmg;


    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        } else {
            Destroy(gameObject);
        }
    }

    public void Init(GameObject target) {
        this.target = target;
    }


	void OnTriggerEnter(Collider hit) {
        print(hit.gameObject);
        if (hit.gameObject == target) {
            hit.gameObject.GetComponent<Enemy>().Damage(dmg);
            Destroy(gameObject);
        }
	}
}
