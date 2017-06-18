using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    public float lifetime;
    public float speedInc;
    public float damageInc;
    public int healthAdd;
    public Color color;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material.color = color;
        Destroy(gameObject, lifetime);
        ParticleSystem particles = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        var col = particles.colorOverLifetime;

        Color endColor = color;
        endColor.a = 0;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(color, 0.0f), new GradientColorKey(endColor, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad;
	}

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerStay(Collider col) {
        if (col.gameObject.tag == "Enemy") {
            Enemy script = col.gameObject.GetComponent<Enemy>();
            script.dmgMulti = damageInc;
            script.speedMulti = speedInc;
            script.healthAdd = healthAdd;
        }
    }
}
