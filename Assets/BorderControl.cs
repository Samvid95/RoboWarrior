using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BorderControl : MonoBehaviour {

    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            levelManager.LoadLevel("Lose");
        }

        collision.gameObject.SetActive(false);
    }
}
