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
    public GameObject angellPrefab;
    public GameObject guhaPrefab;
    public GameObject hollanderPrefab;
    public GameObject leineckerPrefab;
    public GameObject meadePrefab;
    public GameObject szumlanskiPrefab;
    public GameObject[] enemies;
    public bool spawnBool = false;
    public int waveNumber;
    public int enemiesAlive;
    public Text waveText;
    public GameObject gameOverScreen;
    public List<Enemy> EnemyList = new List<Enemy>();
    public bool[] moneyGiven;
    public GameObject victoryScreen;
    List<List<GameObject>> waves = new List<List<GameObject>>();

    void Start()
    {
        // possible solution for getting active scene depending on implementation of GameManager
        //currentMap = SceneManager.GetActiveScene().name;
        //Debug.Log(currentMap);
        waveNumber = 0; 
        enemiesAlive = 0;
        waveText.text = waveNumber.ToString();
        moneyGiven = new bool[10];
        for (int i = 0; i < 10; i++)
        {
            moneyGiven[i] = false;
        }
        waves.Add(new List<GameObject> { angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab });
        waves.Add(new List<GameObject> { angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab });
        waves.Add(new List<GameObject> { leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab });
        waves.Add(new List<GameObject> { leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab});
        waves.Add(new List<GameObject> { leineckerPrefab, leineckerPrefab, meadePrefab, leineckerPrefab, leineckerPrefab, meadePrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab });
        waves.Add(new List<GameObject> { meadePrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, meadePrefab, guhaPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab});
        waves.Add(new List<GameObject> { szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, guhaPrefab, guhaPrefab, guhaPrefab, meadePrefab, meadePrefab, meadePrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, guhaPrefab, guhaPrefab, guhaPrefab, meadePrefab, meadePrefab, meadePrefab });
        waves.Add(new List<GameObject> { hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, meadePrefab});
        waves.Add(new List<GameObject> { hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab });
        waves.Add(new List<GameObject> { meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, meadePrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, leineckerPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, szumlanskiPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab, hollanderPrefab,  angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, angellPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, guhaPrefab, meadePrefab});
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
            if (enemiesAlive == 0)
            {
                StartCoroutine(spawner());
                spawnBool = false;
            }
            spawnBool = false;
        }

        // awards money once after wave completion
        if (waveNumber >= 1 && enemiesAlive == 0)
        {
            giveMoney();
        }

        if (victory())
        {
            Debug.Log("Game Over. Players wins.");
            victoryScreen.gameObject.SetActive(true);
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

    public bool victory()
    {
        if (waveNumber >= 10 && enemiesAlive <= 0 && Player.getHealth() > 0)
        {
            return true;
        }
        return false;
    }

    public IEnumerator spawner()
    {
        int i;
        waveNumber++;
        // Alternatively we can have a maximum number of enemies on screen designated. And while the count
        // of enemies (EnemyList.Count) is less than maximum number of enemies, instantiate an enemy
        for (i = 0; i <= waves[waveNumber - 1].Count - 1; i++)
        {
            GameObject newEnemy = Instantiate(waves[waveNumber - 1][i], pathCreator.path.GetPointAtTime(0.0f), Quaternion.identity);
            if (i == 270)
            {
                Enemy speedyMeade = newEnemy.GetComponent<Enemy>();
                speedyMeade.SetSpeed(90);
            }
            enemiesAlive++;
            yield return new WaitForSeconds(0.8f);
        }
    }

    public void RegisterEnemy(Enemy enemy)
    {
        EnemyList.Add(enemy);
        Debug.Log("Enemy added to list.");
    }

    public void UnRegisterEnemy(Enemy enemy)
    {
        EnemyList.Remove(enemy);
        enemy.DestroyEnemy();
    }

    public void DestroyEnemies()
    {
        foreach (Enemy enemy in EnemyList)
        {
            enemy.DestroyEnemy();
        }
        EnemyList.Clear();
    }

    public void giveMoney()
    {
        // only awards money if money has not been awarded for a specific wave
        if (!moneyGiven[waveNumber - 1])
        {
            Player.setMoney(Player.getMoney() + 100);
            moneyGiven[waveNumber - 1] = true;
        }
    }
}