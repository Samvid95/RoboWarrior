using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDownSlider : MonoBehaviour {

    private Image fillImg;

    float maxHealth;

	// Use this for initialization
	void Start () {
        fillImg = GetComponent<Image>();
        maxHealth = PlayerHealthManager.health;
	}
	
	// Update is called once per frame
	void Update () {
        fillImg.fillAmount = (float)PlayerHealthManager.health / maxHealth;
	}
}
