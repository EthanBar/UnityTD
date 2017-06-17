using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    Text text;

    public Animator anim;
    int prevPoint;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Coins: " + ScoreManager.points;
        if (prevPoint < ScoreManager.points) {
            anim.Play("Coin");
        }
        prevPoint = ScoreManager.points;
	}
}
