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
    public bool spawnBool = false;
    public Text waveText;
    public bool[] moneyGiven;

    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public GameObject pauseMenu;

    public int waveNumber;
    public int enemiesAlive;
    public GameObject[] enemies;
    public List<Enemy> EnemyList = new List<Enemy>();
    public List<GameObject> wave;

    public AdventureSpawner adventureSpawner;
    public SurvivalSpawner survivalSpawner;

    public bool isPaused = false;

    private int GameMode;
    private int xp;
    private User user;

    public void togglePauseMode()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1.0f;
        if (isPaused)
        {
            pauseMenu.gameObject.SetActive(true);
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        // possible solution for getting active scene depending on implementation of GameManager
        //currentMap = SceneManager.GetActiveScene().name;
        //Debug.Log(currentMap);
        Application.targetFrameRate = 60;
        enemiesAlive = 0;

        moneyGiven = new bool[10];
        for (int i = 0; i < 10; i++)
        {
            moneyGiven[i] = false;
        }

        GameMode = PlayerPrefs.GetInt("GameMode");

        if (GameMode == 0)
        {
            adventureSpawner = new AdventureSpawner(enemies);
            waveNumber = adventureSpawner.getWaveNumber();
        }
        else if (GameMode == 1)
        {
            survivalSpawner = new SurvivalSpawner(enemies);
            waveNumber = survivalSpawner.getWaveNumber();
        }

        waveText.text = waveNumber.ToString();
        user = AuthManager.currentUser;
        xp = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPaused)
        {
            return;
        }

        if (Player.getHealth() <= 0)
        {
            Debug.Log("Lives is 0. Game over.");
            gameOverScreen.gameObject.SetActive(true);
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

        // awards money and experience once after wave completion
        if (waveNumber >= 1 && enemiesAlive == 0)
        {
            giveMoney();
        }

        if (victory())
        {
            Debug.Log("Game Over. Players wins.");
            victoryScreen.gameObject.SetActive(true);
        }

        if (GameMode == 0)
        {
            waveNumber = adventureSpawner.getWaveNumber();
        }
        else
        {
            waveNumber = survivalSpawner.getWaveNumber();
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
        if (GameMode == 0)
        {
            if (adventureSpawner.getWaveNumber() >= 10 && enemiesAlive <= 0 && Player.getHealth() > 0)
            {
                if (user.getHighestWave() > waveNumber)
                    CloudFunctions.SetHighestWave(waveNumber);

                CloudFunctions.addXP(1000 + xp);
                return true;
            }
        }
        else if (GameMode == 1)
        {
            if (survivalSpawner.getWaveNumber() >= 100 && enemiesAlive <= 0 && Player.getHealth() > 0)
            {
                if (user.getHighestWave() > waveNumber)
                    CloudFunctions.SetHighestWave(waveNumber);

                CloudFunctions.addXP(1000 + xp);
                return true;
            }
        }
        return false;
    }

    private void giveXP()
    {
        if (user == null)
            return;


        xp += 100;
    }

    public IEnumerator spawner()
    {
        if (GameMode == 0)
        {
            wave = adventureSpawner.GetNextWave();
            foreach (GameObject enemy in wave)
            {
                GameObject spawnedEnemy = Instantiate(enemy, pathCreator.path.GetPointAtTime(0.0f), Quaternion.identity);
                if (adventureSpawner.getWaveNumber() > 10 && spawnedEnemy.name.Equals("meade"))
                    spawnedEnemy.GetComponent<Enemy>().SetSpeed(90);

                enemiesAlive++;
                yield return new WaitForSeconds(0.8f);
            }
        }
        else
        {
            wave = survivalSpawner.GetNextWave();
            foreach (GameObject enemy in wave)
            {
                GameObject spawnedEnemy = Instantiate(enemy, pathCreator.path.GetPointAtTime(0.0f), Quaternion.identity);
                if (survivalSpawner.getWaveNumber() > 10 && spawnedEnemy.name.Equals("meade"))
                    spawnedEnemy.GetComponent<Enemy>().SetSpeed(90);

                enemiesAlive++;
                yield return new WaitForSeconds(0.8f);
            }
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
        xp += 5;
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
            giveXP();
        }
    }

    public void ToMainMenuFromPause()
    {
        Time.timeScale = 1.0f;
        CloudFunctions.addXP(xp);
        SceneManager.LoadScene(sceneName: "MenuScene");
    }
}