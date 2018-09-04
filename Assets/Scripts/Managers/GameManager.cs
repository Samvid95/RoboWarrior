using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool Win = false;
    public static bool Lose= false;

    public GameObject WinPanel;
    public GameObject LostPanel;

    public GameObject roboWarrior;
    public GameObject enemyManager;

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void OnEnable()
    {
    /*    GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(allEnemies != null)
        {
            foreach (GameObject obj in allEnemies)
            {
                Destroy(obj);
            }
        }
        allEnemies = GameObject.FindGameObjectsWithTag("Spikey");
        if(allEnemies != null)
        {
            foreach (GameObject obj in allEnemies)
            {
                Destroy(obj);
            }

        }*/

        PlayerHealthManager.HealthZero += PlayerLost;
        CountDownTimer.TimeZero += PlayerLost;
        StatController.KilledEnemies += PlayerWon;
        BorderControl.DroppedOut += PlayerLost;

        roboWarrior.SetActive(true);
        enemyManager.SetActive(true);
        EnemyManager.currentEnemies = 0;
        PlayerHealthManager.health = 200;
        PlayerStatManager.ChomperKills = 0;
        PlayerStatManager.SpitterKills = 0;
        CountDownTimer.timeAmt = 180;

        Win = false;
        Lose = false;
        WinPanel.SetActive(false);
        LostPanel.SetActive(false);
    }

    private void OnDisable()
    {
        PlayerHealthManager.HealthZero -= PlayerLost;
        CountDownTimer.TimeZero -= PlayerLost;
        StatController.KilledEnemies -= PlayerWon;
        BorderControl.DroppedOut -= PlayerLost;
    }


    void PlayerLost()
    {
        StopEverything();
        Lose = true;
        LostPanel.SetActive(true);
        Debug.LogWarning("Player Lost");
        //Turn on the panel! 
    }

    void PlayerWon()
    {
        StopEverything();
        Win = true;
        WinPanel.SetActive(true);
        Debug.LogWarning("Player Won!");
    }

    void StopEverything()
    {
        /*  GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
          foreach(GameObject obj in allEnemies)
          {
              Destroy(obj);
          }
          allEnemies = GameObject.FindGameObjectsWithTag("Spikey");
          foreach (GameObject obj in allEnemies)
          {
              Destroy(obj);
          }*/
       // enemyManager.SetActive(false);
       // roboWarrior.SetActive(false);
    }

    public void ChangeScene()
    {
        levelManager.LoadLevel("Lose");
    }
}
