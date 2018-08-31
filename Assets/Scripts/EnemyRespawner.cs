using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour {

    public GameObject Enemy1;
    public GameObject Enemy2;
    public Transform place1;
    public Transform place2;

    private GameObject enemy1;
    private GameObject enemy2;
       

	// Use this for initialization
	void Start () {
        enemy1 = Instantiate(Enemy1, place1);
        enemy2 = Instantiate(Enemy2, place2);
    }

    private void OnEnable()
    {
        OpponentHealth.OnZeroHealth += SpawnEnemy;
    }

    private void OnDisable()
    {
        OpponentHealth.OnZeroHealth -= SpawnEnemy;
    }

    void SpawnEnemy()
    {
        Invoke("RealSpawn", 5.0f);
    }

    void RealSpawn()
    {
        if (!GameObject.Find("Enemy1"))
        {
            enemy1 = Instantiate(Enemy1, place1);
            enemy1.name = "Enemy1";
        }
        else
        {
            enemy2 = Instantiate(Enemy2, place2);
            enemy2.name = "Enemy2";
        }
    }
    // Update is called once per frame
    void Update () {


    }



}
