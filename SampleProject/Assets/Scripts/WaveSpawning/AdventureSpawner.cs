﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class AdventureSpawner : WaveSpawner
{
    private int waveNumber;

    public AdventureSpawner(GameObject[] enemies) : base(enemies)
    {
        waveNumber = 1;
    }

    /*
     * List<GameObject> wave = adventureSpawner.GetWave(waveNumber++);

        foreach (GameObject enemy in wave)
        {
            GameObject spawnedEnemy = Instantiate(enemy, pathCreator.path.GetPointAtTime(0.0f), Quaternion.identity);

            if (waveNumber > 10 && spawnedEnemy.name.Equals("meade"))
                spawnedEnemy.GetComponent<Enemy>().SetSpeed(90);

            enemiesAlive++;
            yield return new WaitForSeconds(0.8f);
        }
     */

    public List<GameObject> GetWave(int waveNum)
    {
        if (waveNumber > 10)
        {
            Debug.Log("Attention: Wave Number maxes out at 10. Cannot spawn anymore.");
            return null;
        }

        List<GameObject> wave = new List<GameObject>();

        Debug.Log($"Wave: {waveNum}");
        switch (waveNum)
        {
            case 1:
                wave = SpawnEnemy("angell", 8, wave);
                break;
            case 2:
                wave = SpawnEnemy("angell", 12, wave);
                wave = SpawnEnemy("leinecker", 4, wave);
                break;
            case 3:
                wave = SpawnEnemy("leinecker", 10, wave);
                wave = SpawnEnemy("szum", 6, wave);
                wave = SpawnEnemy("angell", 12, wave);
                break;
            case 4:
                wave = SpawnEnemy("leinecker", 10, wave);
                wave = SpawnEnemy("szum", 24, wave);
                break;
            case 5:
                wave = SpawnEnemy("leinecker", 2, wave);
                wave = SpawnEnemy("meade", 1, wave);
                wave = SpawnEnemy("leinecker", 2, wave);
                wave = SpawnEnemy("meade", 1, wave);
                wave = SpawnEnemy("leinecker", 4, wave);
                wave = SpawnEnemy("meade", 2, wave);
                wave = SpawnEnemy("szum", 8, wave);
                break;
            case 6:
                wave = SpawnEnemy("meade", 1, wave);
                wave = SpawnEnemy("leinecker", 4, wave);
                wave = SpawnEnemy("angell", 4, wave);
                wave = SpawnEnemy("szum", 10, wave);
                wave = SpawnEnemy("meade", 1, wave);
                wave = SpawnEnemy("guha", 1, wave);
                wave = SpawnEnemy("angell", 4, wave);
                wave = SpawnEnemy("leinecker", 4, wave);
                break;
            case 7:
                wave = SpawnEnemy("szum", 20, wave);
                wave = SpawnEnemy("guha", 3, wave);
                wave = SpawnEnemy("meade", 5, wave);
                wave = SpawnEnemy("szum", 20, wave);
                wave = SpawnEnemy("guha", 3, wave);
                wave = SpawnEnemy("meade", 5, wave);
                break;
            case 8:
                wave = SpawnEnemy("hollander", 5, wave);
                wave = SpawnEnemy("leinecker", 5, wave);
                wave = SpawnEnemy("hollander", 5, wave);
                wave = SpawnEnemy("angell", 20, wave);
                wave = SpawnEnemy("meade", 1, wave);
                break;
            case 9:
                wave = SpawnEnemy("hollander", 50, wave);
                wave = SpawnEnemy("leinecker", 5, wave);
                wave = SpawnEnemy("szum", 5, wave);
                wave = SpawnEnemy("leinecker", 5, wave);
                wave = SpawnEnemy("szum", 5, wave);
                wave = SpawnEnemy("guha", 10, wave);
                wave = SpawnEnemy("hollander", 10, wave);
                break;
            case 10:
                wave = SpawnEnemy("meade", 20, wave);
                wave = SpawnEnemy("leinecker", 20, wave);
                wave = SpawnEnemy("szum", 10, wave);
                wave = SpawnEnemy("hollander", 50, wave);
                wave = SpawnEnemy("angell", 100, wave);
                wave = SpawnEnemy("guha", 50, wave);
                wave = SpawnEnemy("meade", 1, wave);
                break;
            default:
                break;
        }

        return wave;
    }
}