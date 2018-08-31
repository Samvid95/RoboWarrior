using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float time = 60.0f;

    public Text sceneText;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time < 0)
        {
            SceneManager.LoadScene("EndScene");
        }
        int timeLeft = (int)time;
        sceneText.text = "Time Left: " + timeLeft;
	}
}
