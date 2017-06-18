using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaDisplay : MonoBehaviour {

    Text text;

    public Animator anim;
    int prevMana;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Mana: " + DataMan.mana;
        if (prevMana < DataMan.mana) {
            anim.Play("Coin");
        }
        prevMana = DataMan.mana;
	}
}
