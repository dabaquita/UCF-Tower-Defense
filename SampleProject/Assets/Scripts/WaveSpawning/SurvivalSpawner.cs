using System.Collections.Generic;
using UnityEngine;

public class SurvivalSpawner : WaveSpawner
{
    private int waveNumber;

    public SurvivalSpawner(GameObject[] enemies) : base(enemies)
    {
        waveNumber = 0;
    }
}
