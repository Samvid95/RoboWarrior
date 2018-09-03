using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    public float autoLoadNextLevelAfter;

	// Use this for initialization
	void Start () {
		if(autoLoadNextLevelAfter == 0)
        {
            Debug.Log("Auto load is disabled");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
	}
	
	public void LoadLevel(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit_Requested()
    {
        Application.Quit();
    }
}
