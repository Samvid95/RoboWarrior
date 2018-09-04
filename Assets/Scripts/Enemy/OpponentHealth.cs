using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Managing the Opponent's health and deleting if needed.
/// </summary>
public class OpponentHealth : MonoBehaviour {
    public int health = 40;

    //Come on kids killing enemies are good and always listen to when they are dead. 
    public delegate void NoHealth(Transform trans);
    public static event NoHealth OnZeroHealth;

    private Color originalColor;

    private Animator anim;

    private bool playOnce = true;

	// Use this for initialization
	void Start () {
        originalColor = GetComponent<SpriteRenderer>().color;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    /// <summary>
    /// Destroying dead enemy objects and variable management of the player as well. 
    /// </summary>
	void Update () {
		if(health <= 0)
        {
            if (playOnce)
            {
                GetComponent<ShootingScript>().CancelInvoke();
                EnemyManager.currentEnemies--;
                anim.SetTrigger("dead");
                Destroy(gameObject, 1.2f);
                playOnce = false;
                if(gameObject.name == "Spitter")
                {
                    PlayerStatManager.SpitterKills++;
                }
                else
                {
                    PlayerStatManager.ChomperKills++;
                }
                if (OnZeroHealth != null)
                {
                    OnZeroHealth(transform.parent);
                }
            }
            
        }
	}
    /// <summary>
    /// Just adding a damage on the Enemies and change color to give player a little bit feedback on when they hit the player. 
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        health -= damage;
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("ResetColor", 0.2f);
    }

    void ResetColor()
    {
        GetComponent<SpriteRenderer>().color = originalColor;
    }
}
