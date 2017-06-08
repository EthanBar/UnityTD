using UnityEngine;

public class Enemy : MonoBehaviour {

    public int Hp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void Update () {
        if (Hp < 0) {
            Destroy(gameObject);
        }
	}

	public void Damage(int damage) {
		Hp -= damage;
	}
}
