using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    GameObject target;
    public float speed;


    int dmg;


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

    public void Init(GameObject target, int dmg, Transform parent) {
        transform.parent = parent;
        this.target = target;
        this.dmg = dmg;
    }


	void OnTriggerEnter(Collider hit) {
        if (hit.gameObject == target) {
            hit.gameObject.GetComponent<Enemy>().Damage(dmg);
            Destroy(gameObject);
        }
	}
}
