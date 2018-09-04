using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the main class for Enemy Management. It will ranomly spawn Enemies on the map across positoins passed by Transform array.
/// </summary>
public class EnemyManager : MonoBehaviour {


    //To make sure there are only 8 enemies in total in anytime of the game.
    public static int currentEnemies = 0;

    public GameObject spitter;
    public GameObject chomper;

    public Transform[] spawnPoints;

    /// <summary>
    /// Resetting all the things everytime it starts
    /// </summary>
    private void OnEnable()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        InvokeRepeating("SpawnEnemy", 2.5f, 3);
    }

    /// <summary>
    /// Spawning the enemies randomly and at random locations as well.  
    /// Also maintaining current number of enemies.
    /// </summary>
    public void SpawnEnemy()
    {
        //Debug.Log("Coming into spawning enemies!");
        float rand = Random.Range(0.0f, 1.0f);
        if(rand > 0.5f && currentEnemies < 8)
        {
            float randEnemy = Random.Range(0.0f, 1.0f);
            int randPosition = Random.Range(1, spawnPoints.Length);
                if (randEnemy < 0.5f)
                {
                    GameObject enemy = Instantiate(spitter, spawnPoints[randPosition]);
                    enemy.name = "Spitter";
                }
                else
                {
                    GameObject enemy = Instantiate(chomper, spawnPoints[randPosition]);
                    enemy.name = "Chomper";
                }
                //Total number of enemies is maintained by this class right here! 
                currentEnemies++;    
        }
    }

}
