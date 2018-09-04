using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {
    //It's a simple timer script. 
    Image fillImage;
    public static float timeAmt = 180;
    float time = 0;

    //Interested people just come on and keep track when the person ran out of time. 
    public delegate void TimeUp();
    public static event TimeUp TimeZero;

	// Use this for initialization
	void Start () {
        fillImage = GetComponent<Image>();
        time = timeAmt;
	}
	
	// Update is called once per frame
	void Update () {
		if(time > 0)
        {
            time -= Time.deltaTime;
            fillImage.fillAmount = time / timeAmt; 
        }
        else
        {
            if(TimeZero != null)
            {
                TimeZero();
            }
        }
	}
}
