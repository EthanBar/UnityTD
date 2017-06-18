using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    [HideInInspector]
    public GameObject target;
    public float speed;
    [HideInInspector]
    public int dmg;


    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (target == null) Destroy(gameObject); // If target is not found, disappear
    }

    // Init shot with data about shot
    public void Init(GameObject target, int dmg, Transform parent) {
        //transform.parent = parent;
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        this.target = target;
        this.dmg = dmg;
    }
}
