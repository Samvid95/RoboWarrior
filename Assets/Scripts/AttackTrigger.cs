using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;
    bool lookingRight = true;

    private bool attacking = false;

    private float onTimer = 0.0f;
    private float onTimerCd = 0.2f;

    private void Awake()
    {
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
