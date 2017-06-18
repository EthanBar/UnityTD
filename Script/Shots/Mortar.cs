﻿using UnityEngine;

public class Mortar : MonoBehaviour {

    public float splash;
    public float timeInAir;
    Rigidbody rb;
    Shot shot;
    bool first = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        shot = GetComponent<Shot>();
	}
	
	// Update is called once per frame
	void Update () {
        if (first) {
            rb.velocity = calculateBestThrowSpeed(transform.position, shot.target.transform.position, timeInAir);
            first = false;
        }
        if (transform.position.y <= 0) {
            print("hit");
            //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            foreach (Transform child in GameObject.Find("Enemy Spawner").transform) {
                Transform enemy = child.Find("Enemy");
                print(Vector3.Distance(transform.position, enemy.position));
                if (Vector3.Distance(transform.position, enemy.position) < splash) {
                    print(child.name);
                    enemy.gameObject.GetComponent<Enemy>().Damage(shot.dmg);
                }
            }
            Destroy(gameObject);
        }
	}

    // Fancy formula I didn't make
    Vector3 calculateBestThrowSpeed(Vector3 origin, Vector3 target, float timeToTarget) {
        // calculate vectors
        Vector3 toTarget = target - origin;
        Vector3 toTargetXZ = toTarget;
        toTargetXZ.y = 0;

        // calculate xz and y
        float y = toTarget.y;
        float xz = toTargetXZ.magnitude;

        // calculate starting speeds for xz and y. Physics forumulase deltaX = v0 * t + 1/2 * a * t * t
        // where a is "-gravity" but only on the y plane, and a is 0 in xz plane.
        // so xz = v0xz * t => v0xz = xz / t
        // and y = v0y * t - 1/2 * gravity * t * t => v0y * t = y + 1/2 * gravity * t * t => v0y = y / t + 1/2 * gravity * t
        float t = timeToTarget;
        float v0y = y / t + 0.5f * Physics.gravity.magnitude * t;
        float v0xz = xz / t;

        // create result vector for calculated starting speeds
        Vector3 result = toTargetXZ.normalized;        // get direction of xz but with magnitude 1
        result *= v0xz;                                // set magnitude of xz to v0xz (starting speed in xz plane)
        result.y = v0y;                                // set y to v0y (starting speed of y plane)

        return result;
    }
}
