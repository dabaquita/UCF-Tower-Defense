using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWaveStats : MonoBehaviour
{
    public Text highestWave;
    public Text currentLevel;

    void Update()
    {
        if (AuthManager.currentUser != null)
        {
            highestWave.text = AuthManager.currentUser.getHighestWave().ToString();
            currentLevel.text = AuthManager.currentUser.getCurrentLevel().ToString();
        }
        else
        {
            highestWave.text = "0";
            currentLevel.text = "0";
        }
    }
}
