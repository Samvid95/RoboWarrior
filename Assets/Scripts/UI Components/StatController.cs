using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class controls the information about the Canvas of player progress. 
/// </summary>
public class StatController : MonoBehaviour {

    public GameObject chomperCompleted;
    public GameObject spitterCompleted;
    public TextMeshProUGUI chomperKills;
    public TextMeshProUGUI spitterKills;

    public delegate void AllDead();
    public static event AllDead KilledEnemies;

    public int maxKills = 4;
	// Use this for initialization
	void OnEnable () {
        chomperCompleted.SetActive(false);
        spitterCompleted.SetActive(false);

        PlayerMovementController.OnFlip += CanvasFlip;
	}

    private void OnDisable()
    {
        PlayerMovementController.OnFlip -= CanvasFlip;
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

        //When killed all the enemies we will send the values to the game manager that player actually won! 
        if (PlayerStatManager.ChomperKills >= maxKills && PlayerStatManager.SpitterKills >= maxKills)
        {
            if (KilledEnemies != null)
            {
                KilledEnemies();
            }
        }
    }

    void CanvasFlip()
    {
        Vector3 currRotation = GetComponent<RectTransform>().rotation.eulerAngles;
        currRotation += new Vector3(0, 180, 0);
        GetComponent<RectTransform>().rotation = Quaternion.Euler(currRotation);
    }
}
