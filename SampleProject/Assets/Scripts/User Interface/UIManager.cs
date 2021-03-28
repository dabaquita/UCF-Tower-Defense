using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Firebase.Auth;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        //SceneManager.LoadScene("FIRST_SCENE_OF_THE_GAME");
    }

    public void doExitGame()
    {
        Debug.Log("Exiting the game");

        AuthManager.signout();

        Application.Quit();
    }

}
