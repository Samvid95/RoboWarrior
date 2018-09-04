using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class keeps track when you are punching. 
/// The biggest reason of having all Enter, Stay and Exit is because some players just smash the attack button constantly so box never gets turned off so in that case I needed Stay method. 
/// </summary>
public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

    private bool attacking = false;

    private float onTimer = 0.0f;
    private float onTimerCd = 0.2f;

    private void Awake()
    {

    }

    private void OnDisable()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger == true && collision.CompareTag("Enemy") )
        {
            attacking = true;
            onTimer = onTimerCd;
            
        } 
        
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (attacking && collision.isTrigger == true && collision.CompareTag("Enemy"))
        {
            if (onTimer > 0)
            {
                onTimer -= Time.deltaTime;
            }
            else
            {
                collision.SendMessageUpwards("Damage", dmg);
                onTimer = 0.5f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attacking = false;
    }

    
}
