using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static int currentEnemies = 0;

    public GameObject spitter;
    public GameObject chomper;

    public Transform[] spawnPoints;

    private Dictionary<Transform, bool> myDictionary = new Dictionary<Transform, bool>();

    private List<GameObject> enemies = new List<GameObject>(8);

    private void OnEnable()
    {
        OpponentHealth.OnZeroHealth += ReWorkDictionary;
        enemies.Clear();
        spawnPoints = GetComponentsInChildren<Transform>();
        Invoke("Setup", 2.0f);
        
    }

    private void Update()
    {
    }

    public void Setup()
    {
        for (int i = 1; i < spawnPoints.Length; i++)
        {
            myDictionary.Add(spawnPoints[i], false);
        }
        InvokeRepeating("SpawnEnemy", 0.5f, 3);
    }

    public void SpawnEnemy()
    {
        //Debug.Log("Coming into spawning enemies!");
        float rand = Random.Range(0.0f, 1.0f);
        if(rand > 0.5f && currentEnemies < 8)
        {
            float randEnemy = Random.Range(0.0f, 1.0f);
            int randPosition = Random.Range(1, myDictionary.Count);
                if (randEnemy < 0.5f)
                {
                    GameObject enemy = Instantiate(spitter, spawnPoints[randPosition]);
                    enemy.name = "Spitter";
                    myDictionary[spawnPoints[randPosition]] = true;
                   // enemies.Add(enemy);
                }
                else
                {
                    GameObject enemy = Instantiate(chomper, spawnPoints[randPosition]);
                    enemy.name = "Chomper";
                    myDictionary[spawnPoints[randPosition]] = true;
                   // enemies.Add(enemy);
                }
                currentEnemies++;
               // Debug.Log("Successful spawn!");          
        }
    }

    public void ReWorkDictionary(Transform parentTransform)
    {
        Debug.Log("The position is:" + parentTransform.position);
        myDictionary[parentTransform] = false;
    }
}
