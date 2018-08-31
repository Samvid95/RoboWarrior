using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeyScript : MonoBehaviour {

    public int dmg = 20;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This is for the bullet! 
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().Damage(dmg);
        }
    }
}
