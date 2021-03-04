﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string currentMap;

    // Update is called once per frame
    void Update()
    {
        if (Player.getHealth() <= 0)
        {
            Debug.Log("Lives is 0. Game over.");
            SceneManager.LoadScene(sceneName:"MenuScene");
        }
    }

    public void setMap(string map)
    {
        currentMap = map;
    }

    public string getMap()
    {
        return currentMap;
    }

    public void resetGame()
    {
        currentMap = null;
    }
}
