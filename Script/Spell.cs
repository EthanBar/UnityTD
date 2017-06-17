using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    public float lifetime;
    public float speedInc;
    public float damageInc;
    public Color color;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material.color = color;
        Destroy(gameObject, lifetime);
	}

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerStay(Collider col) {
        if (col.gameObject.tag == "Enemy") {
            Enemy script = col.gameObject.GetComponent<Enemy>();
            script.dmgMulti = damageInc;
            script.speedMulti = speedInc;
        }
    }
}
