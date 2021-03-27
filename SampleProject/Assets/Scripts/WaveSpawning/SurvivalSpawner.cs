using System.Collections.Generic;
using UnityEngine;

public class SurvivalSpawner : WaveSpawner
{
    private int waveNumber;
    private string[] enemyNames;

    /*
     * int Wave::enemiesPerWave()
{
    int rsp = (int)((0.15 * this->pWaveNumber) * (24 + 6 * (this->pWaveDifficulty-1)));
    return rsp;
}
     */

    public SurvivalSpawner(GameObject[] enemies) : base(enemies)
    {
        waveNumber = 0;

        enemyNames = new string[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyNames[i] = enemies[i].name;
        }
    }

    private List<GameObject> GetNextWave()
    {
        List<GameObject> wave = new List<GameObject>();



        return wave;
    }

    private int GetNumEnemiesPerWave()
    {
        return (int)(0.15 * (waveNumber + 1)) * (20 * (waveNumber + 1));
    }
}
