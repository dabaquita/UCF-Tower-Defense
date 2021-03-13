using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PathCreation;

public class GameManager : MonoBehaviour
{
    private string currentMap;
    public PathCreator pathCreator;
    public GameObject hollanderPrefab;
    public GameObject[] enemies;
    public bool spawnBool = false;
    public int waveNumber;
    public int enemiesAlive;
    public Text waveText;
    public GameObject gameOverScreen;

    void Start()
    {
        // possible solution for getting active scene depending on implementation of GameManager
        //currentMap = SceneManager.GetActiveScene().name;
        //Debug.Log(currentMap);
        enemies = new GameObject[10];
        waveNumber = 0;
        enemiesAlive = 0;
        waveText.text = waveNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.getHealth() <= 0)
        {
            Debug.Log("Lives is 0. Game over.");
            gameOverScreen.gameObject.SetActive(true);
            //SceneManager.LoadScene(sceneName: "MenuScene");
        }

        if (spawnBool)
        {
            StartCoroutine(spawner());
            spawnBool = false;
        }

        if (waveNumber >= 10)
        {
            victory();
            Debug.Log("Game Over. Players wins.");
        }
        waveText.text = waveNumber.ToString();

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

    public void startSpawning()
    {
        spawnBool = true; // triggered by play button
    }

    public void victory()
    {
        // show victory screen with link to home screen
        // give player exp
    }

    public IEnumerator spawner()
    {
        int i;
        waveNumber++;
        for (i = 0; i <= waveNumber - 1; i++)
        {
            // creates new hollander prefab and puts it at the start of the map
            GameObject newEnemy = Instantiate(hollanderPrefab, pathCreator.path.GetPointAtTime(0.0f), Quaternion.identity);
            newEnemy.transform.localScale = new Vector3(1, 1, 1);
            enemies[i] = newEnemy;
            enemiesAlive++;

            // logs action and waits one second to spawn next enemy
            Debug.Log("Hollander spawned.");
            yield return new WaitForSeconds(1.0f);
        }
    }
}
