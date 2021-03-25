using System;
using UnityEngine;
using System.Collections.Generic;

public class WaveSpawner
{
    private Dictionary<string, GameObject> enemyDictionary;

    public WaveSpawner(GameObject[] enemies)
    {
        enemyDictionary = new Dictionary<string, GameObject>();

        foreach (GameObject enemy in enemies)
        {
            enemyDictionary[enemy.name] = enemy;
        }
    }

    public List<GameObject> SpawnEnemy(string name, int num, List<GameObject> enemies)
    {
        if (!enemyDictionary.ContainsKey(name))
        {
            Debug.LogError($"ERROR: Enemy name {name} not in enemyDictionary. Please add to GameManager.");
            return null;
        }

        for (int i = 0; i < num; i++)
        {
            enemies.Add(enemyDictionary[name]);
            Debug.Log($"Added enemy: {enemies}");
        }

        return enemies;
    }
}


