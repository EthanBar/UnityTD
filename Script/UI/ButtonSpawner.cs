﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour {

    public GameObject[] enemys;
    public GameObject[] towers;
    public GameObject[] spells;
    public GameObject button;
    public GameObject canvas;

    [HideInInspector]
    public static GameObject activeEnemy, activeTower, activeSpell;

	// Use this for initialization
	void Start () {
        activeTower = towers[0];
        activeSpell = spells[0];
        activeEnemy = enemys[0];

        int incAmt = Screen.width / (towers.Length + spells.Length + enemys.Length);
        int x = incAmt/2;
        foreach (GameObject enemy in enemys) {
            GameObject but = Instantiate(button) as GameObject;
            but.transform.SetParent(transform, false);
            but.transform.GetChild(0).GetComponent<Text>().text = enemy.name;
            but.SetActive(true);
            RectTransform trans = but.GetComponent<RectTransform>();
            trans.position = new Vector2(x, 20f);
            trans.sizeDelta = new Vector2(incAmt, 40f);
            Button butComp = but.GetComponent<Button>();
            Image img = but.GetComponent<Image>();
            butComp.onClick.AddListener(delegate { // I love C#
                SetEnemy(enemy);
            });
            x += incAmt;
        }
        foreach (GameObject tower in towers) {
            GameObject but = Instantiate(button) as GameObject;
            but.transform.SetParent(transform, false);
            but.transform.GetChild(0).GetComponent<Text>().text = tower.name;
            but.SetActive(true);
            RectTransform trans = but.GetComponent<RectTransform>();
            trans.position = new Vector2(x, 20f);
            trans.sizeDelta = new Vector2(incAmt, 40f);
            Button butComp = but.GetComponent<Button>();
            Image img = but.GetComponent<Image>();
            butComp.onClick.AddListener(delegate { // I love C#
                SetTower(tower);
            });
            x += incAmt;
        }
        foreach (GameObject spell in spells) {
            GameObject but = Instantiate(button) as GameObject;
            but.transform.SetParent(transform, false);
            but.transform.GetChild(0).GetComponent<Text>().text = spell.name;
            but.SetActive(true);
            RectTransform trans = but.GetComponent<RectTransform>();
            trans.position = new Vector2(x, 20f);
            trans.sizeDelta = new Vector2(incAmt, 40f);
            Button butComp = but.GetComponent<Button>();
            Image img = but.GetComponent<Image>();
            butComp.onClick.AddListener(delegate { // I love C#
                SetSpell(spell);
            });
            x += incAmt;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void SetEnemy(GameObject enemy) {
        activeEnemy = enemy;
    }

    void SetTower(GameObject tower) {
        activeTower = tower;
    }

    void SetSpell(GameObject spell) {
        activeSpell = spell;
    }
}