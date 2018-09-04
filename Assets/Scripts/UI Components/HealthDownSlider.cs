using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Keeps track of the health and make it proper.
/// Improvemnt: I could have incorporate this in the statController but I am out of time. 
/// </summary>
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
