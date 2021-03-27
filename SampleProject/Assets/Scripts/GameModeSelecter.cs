using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSelecter : MonoBehaviour
{
    // sets GameMode to 0, for Adventure
    public void chooseAdventure()
    {
        PlayerPrefs.SetInt("GameMode", 0);
    }

    // sets GameMode to 1, for Survival
    public void chooseSurvival()
    {
        PlayerPrefs.SetInt("GameMode", 1);
    }
}
