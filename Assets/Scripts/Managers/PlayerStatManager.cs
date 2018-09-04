using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour {

    public static int SpitterKills  = 0;
    public static int ChomperKills = 0;

    private void OnEnable()
    {
        SpitterKills = ChomperKills = 0;
    }
}
