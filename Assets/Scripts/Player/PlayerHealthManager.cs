using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Managing the player's health.
/// </summary>
public class PlayerHealthManager : MonoBehaviour {

    public static int health = 200;

    public GameObject explosion;

    //LIKE, SHARE & SUBSCRIBE if you like to learn more when the player is dead! 
    public delegate void PlayerLost();
    public static event PlayerLost HealthZero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {

           if(HealthZero != null)
            {
                HealthZero();
            }
        }
	}
    /// <summary>
    /// Most of the time its values are coming from the colliders and dealing damage to the player.
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        GameObject boomboom = Instantiate(explosion, transform);
        Destroy(boomboom, 3.5f);
        health -= damage;
    }


}
