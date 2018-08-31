using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;
    bool lookingRight = true;

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
            collision.SendMessageUpwards("Damage", dmg);
        } 
        
       
    }

    void ChangePosition()
    {
        if (lookingRight)
        {
            this.transform.position -= new Vector3(2.152f, 0, 0);
            lookingRight = false;
        }
        else
        {
            this.transform.position += new Vector3(2.152f, 0, 0);
            lookingRight = true;
        }
    }
}
