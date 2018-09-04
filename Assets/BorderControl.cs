using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BorderControl : MonoBehaviour {

    public LevelManager levelManager;
    public delegate void PlayerFellDown();
    public static event PlayerFellDown DroppedOut;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
          if(DroppedOut != null)
            {
                DroppedOut();
            }
            // levelManager.LoadLevel("Lose");
        }

       // collision.gameObject.SetActive(false);
    }
}
