using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        //SceneManager.LoadScene("FIRST_SCENE_OF_THE_GAME");
    }

<<<<<<< HEAD
    public void exitGame()
    {
=======
    public void doExitGame()
    {
        Debug.Log("Exiting the game");
>>>>>>> fc2610c3bd2912a4560a4d2d5eb21267d1c4354f
        Application.Quit();
    }

}
