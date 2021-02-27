﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Enemy2 : MonoBehaviour
{
    public int Health;
    public static int startingHealth = 50;

    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;

    // Start is called before the first frame update
    void Start()
    {
        Health = Enemy2.startingHealth;
        transform.position = pathCreator.path.GetPointAtTime(0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);


        if (IsDead())
        {
            DestroyEnemy();
        }

        // will be true when the enemy hits the end of the map while still having health
        // using 3 since the array in Path.cs only has 4 segments and I assume that's the last
        // one

        if (IsAtEnd())
        {
            DamagePlayer();
            DestroyEnemy();
        }
    }

    public void DamagePlayer()
    {
        Player.Health -= 10;
        DestroyEnemy();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            return true;
        }
        return false;
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public bool IsAtEnd()
    {
        if (transform.position == pathCreator.path.GetPoint(730))
        {
            return true;
        }
        return false;
    }
}
