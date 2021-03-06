﻿using System.Collections.Generic;
using UnityEngine;

public class SurvivalSpawner : WaveSpawner
{
    private int waveNumber;
    private string[] enemyNames;
    public int[] enemyDifficultyValues;
    private System.Random rand = new System.Random();

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
        enemyDifficultyValues = new int[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyNames[i] = enemies[i].name;
            enemyDifficultyValues[i] = enemies[i].GetComponent<Enemy>().GetDifficltyValue();
        }
    }

    public int getWaveNumber()
    {
        return waveNumber;
    }

    public List<GameObject> GetNextWave()
    {
        List<GameObject> wave = new List<GameObject>();
        int waveDifficulty = GetRandomEnemyDifficultyValues();
        int jindex = 0;
        while (jindex < waveDifficulty)
        {
            int toSpawn = rand.Next(6);
            string toSpawnName = enemyNames[toSpawn];
            jindex += enemyDifficultyValues[toSpawn];
            wave = SpawnEnemy(toSpawnName, 1, wave);
        }
        waveNumber++;
        return wave;
    }

    private int GetNumEnemiesPerWave()
    {
        return (int)(0.15 * (waveNumber + 1)) * (20 * (waveNumber + 1));
    }

    private int GetRandomEnemyDifficultyValues()
    {
        if (waveNumber == 0)
        {
            return (int)(rand.Next(6, 21));
        }
        else
        {
            return (int)(rand.Next(6, 21) * System.Math.Ceiling((waveNumber * .50)));
        }

    }
}
