using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject spitter;
    public GameObject chomper;

    public Transform[] spawnPoints;

    private List<GameObject> enemies = new List<GameObject>(8);

    private void OnEnable()
    {
        enemies.Clear();
        InvokeRepeating("SpawnEnemy", 3, 5);
    }
    
    public void SpawnEnemy()
    {
        float rand = Random.Range(0.0f, 1.0f);
        if(rand > 0.5f && enemies.Count < 8)
        {
            float randEnemy = Random.Range(0.0f, 1.0f);
            int randPosition = Random.Range(0, spawnPoints.Length);

            if (randEnemy < 0.5f) {
                GameObject enemy = Instantiate(spitter, spawnPoints[randPosition]);
                enemies.Add(enemy);
            }
            else
            {
                GameObject enemy = Instantiate(chomper, spawnPoints[randPosition]);
                enemies.Add(enemy);
            }
        }
    }
}
