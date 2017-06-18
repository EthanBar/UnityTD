using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public Transform enemy;
    Vector3 look;

    void Start() {
        look = transform.localPosition;
        //enemy = transform.Find("Enemy");
    }

    void LateUpdate() {
        transform.position = enemy.transform.position + look;
    }
}
