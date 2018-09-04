using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class keeps track when you are punching. 
/// The biggest reason of having all Enter, Stay and Exit is because some players just smash the attack button constantly so box never gets turned off so in that case I needed Stay method. 
/// </summary>
public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;
    bool lookingRight = true;

    private bool attacking = false;

    private float onTimer = 0.0f;
    private float onTimerCd = 0.2f;

    private void Awake()
    {
        //They are listening to the player when it flips so that will help change the position of this trigger.
        PlayerMovementController.OnFlip += ChangePosition;
    }

    private void OnDisable()
    {
        PlayerMovementController.OnFlip -= ChangePosition;
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

    //Change the position of this trigger. If I able to solve the problem of player standing in the air correctly I will remove this part.
    void ChangePosition()
    {
        if (lookingRight)
        {
            this.transform.position -= new Vector3(1.142f, 0, 0);
            lookingRight = false;
        }
        else
        {
            this.transform.position += new Vector3(1.142f, 0, 0);
            lookingRight = true;
        }
    }
}
