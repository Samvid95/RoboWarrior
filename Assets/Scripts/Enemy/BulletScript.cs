using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public int dmg = 20;

    public bool spawnSpikey;

    public GameObject Spikey; 
     
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //This is for the bullet! 
        if (collision.isTrigger == false && collision.CompareTag("Player"))
        {
            collision.SendMessageUpwards("Damage", dmg);
            Destroy(gameObject);
        }
        if(collision.isTrigger == false && collision.CompareTag("Ground"))
        {
            if (spawnSpikey)
            {
                //Spawn a gameobject at this position!!!
                Instantiate(Spikey, transform.position + new Vector3(0, 0.4f,0), Quaternion.identity);
            }

            Destroy(gameObject);
        }
        

    }
}
