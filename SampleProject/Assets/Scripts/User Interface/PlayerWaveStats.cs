using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWaveStats : MonoBehaviour
{
    public Text highestWave;
    public Text currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (AuthManager.currentUser != null)
        {
            highestWave.text = AuthManager.currentUser.highestWave.ToString();
            currentLevel.text = AuthManager.currentUser.currentLevel.ToString();
        }
        else
        {
            highestWave.text = "2";
            currentLevel.text = "1";
        }
    }

    void Update()
    {
        if (AuthManager.currentUser != null)
        {
            highestWave.text = AuthManager.currentUser.highestWave.ToString();
            currentLevel.text = AuthManager.currentUser.currentLevel.ToString();
        }
        else
        {
            highestWave.text = "2";
            currentLevel.text = "1";
        }
    }
}
