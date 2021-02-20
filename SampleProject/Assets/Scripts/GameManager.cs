using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Player.Health <= 0)
        {
            Debug.Log("Lives is 0. Game over.");
            SceneManager.LoadScene(sceneName:"MenuScene");
        }

    }
}
