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
        SceneManager.LoadScene(sceneName: "StudentUnionScene");
    }

    public void ToBounceHouse()
    {
        Debug.Log("BOUNCE BOUNCE");
        SceneManager.LoadScene(sceneName: "BounceHouseScene");
    }

    public void ToCB1()
    {
        SceneManager.LoadScene(sceneName: "CB1ClassroomScene");
    }

    public void ToLibrary()
    {
        SceneManager.LoadScene(sceneName: "LibraryScene");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "MenuScene");
    }
}
