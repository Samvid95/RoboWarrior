using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will look for players dropping out of the platform spaces.
/// </summary>
public class BorderControl : MonoBehaviour {

    public LevelManager levelManager;

    //Here here lurkers, look when the player messes up and robo falls down from the platform. 
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

    }
}
