using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour {


    public LevelManager levelManager;

    public GameObject panel;

    bool panelControl = false;

	public void CloseApplication()
    {
        levelManager.Quit_Requested();
    }

    public void ChangePanelOnOff()
    {
        panelControl = !panelControl;
        if (panelControl)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
