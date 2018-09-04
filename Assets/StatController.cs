using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatController : MonoBehaviour {

    public GameObject chomperCompleted;
    public GameObject spitterCompleted;
    public TextMeshProUGUI chomperKills;
    public TextMeshProUGUI spitterKills;

    public delegate void AllDead();
    public static event AllDead KilledEnemies;

    public int maxKills = 4;
	// Use this for initialization
	void Start () {
        chomperCompleted.SetActive(false);
        spitterCompleted.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        chomperKills.text = "<size=45>x</size><color=black>" + PlayerStatManager.ChomperKills.ToString() + "</color>";
        spitterKills.text = "<size=45>x</size><color=black>" + PlayerStatManager.SpitterKills.ToString() + "</color>";
        
        if (PlayerStatManager.ChomperKills >= maxKills)
        {
            chomperCompleted.SetActive(true);
        }
        else
        {
            chomperCompleted.SetActive(false);
        }
        if (PlayerStatManager.SpitterKills >= maxKills)
        {
            spitterCompleted.SetActive(true);
        }
        else
        {
            spitterCompleted.SetActive(false);
        }
            if (PlayerStatManager.ChomperKills >= maxKills && PlayerStatManager.SpitterKills >= maxKills)
        {
            if (KilledEnemies != null)
            {
                KilledEnemies();
            }
        }
    }
}
