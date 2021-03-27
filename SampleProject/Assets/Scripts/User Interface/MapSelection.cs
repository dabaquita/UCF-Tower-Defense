using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    public void ToMemoryMall()
    {
        SceneManager.LoadScene(sceneName: "MemoryMallScene");
    }

    public void ToGreekRow()
    {
        SceneManager.LoadScene(sceneName: "GreekRowScene");
    }

    public void ToStudentUnion()
    {
        SceneManager.LoadScene(sceneName: "StudentUnion");
    }

    public void ToBounceHouse()
    {
        Debug.Log("BOUNCE BOUNCE");
        SceneManager.LoadScene(sceneName: "BounceHouse");
    }

    public void ToCB1()
    {
        SceneManager.LoadScene(sceneName: "CB2");
    }

    public void ToPub()
    {
        SceneManager.LoadScene(sceneName: "Pub");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "MenuScene");
    }

    public void ToLogin() {
        SceneManager.LoadScene(sceneName: "Login");
    }
}
