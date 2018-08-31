using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

    public int health = 100;
    public Text healthText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            DestroyImmediate(gameObject);
            SceneManager.LoadScene("EndScene");
        }
        healthText.text = "Health: " + health.ToString();
	}

    public void Damage(int damage)
    {
        health -= damage;
    }


}
