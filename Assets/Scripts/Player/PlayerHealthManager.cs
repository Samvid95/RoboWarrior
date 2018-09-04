using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

    public static int health = 200;

    public delegate void PlayerLost();
    public static event PlayerLost HealthZero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
          //  DestroyImmediate(gameObject);
           // SceneManager.LoadScene("Lose");
           if(HealthZero != null)
            {
                HealthZero();
            }
        }
	}

    public void Damage(int damage)
    {
        health -= damage;
    }


}
