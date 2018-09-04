using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keep tracks of when the player punched exactly and keep the triggers on for a little while as well. 
/// </summary>
public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCd = 0.5f;

    public Collider2D attackTrigger;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    /// <summary>
    /// When player presses attack button the hitbox will turn on for 0.5 seconds where it will send out the hit signals to every opponents. 
    /// </summary>
    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            anim.SetTrigger("punched");
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }
        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }


	}
}
