using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Enemy : MonoBehaviour
{
    private int health;
    private const int START_HEALTH = 50;

    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        pathCreator = GameObject.Find("EnemyPath").GetComponent<PathCreator>();
        health = START_HEALTH;
        transform.position = pathCreator.path.GetPointAtTime(0.0f);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.RegisterEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);


        if (IsDead())
        {
            gm.UnRegisterEnemy(this);
            //DestroyEnemy();
        }

        // will be true when the enemy hits the end of the map while still having health
        // using 3 since the array in Path.cs only has 4 segments and I assume that's the last
        // one

        if (IsAtEnd())
        {
            DamagePlayer();
            gm.UnRegisterEnemy(this);
            //DestroyEnemy();
        }
    }

    public void DamagePlayer()
    {
        Player.setHealth(Player.getHealth() - 10);
    }

    public bool IsDead()
    {
        if (health <= 0)
        {
            return true;
        }
        return false;
    }

    public void DestroyEnemy()
    {
        DestroyImmediate(gameObject);
        gm.enemiesAlive--;
    }

    public bool IsAtEnd()
    {
        if (transform.position == pathCreator.path.GetPointAtDistance(999999, EndOfPathInstruction.Stop))
        {
            return true;
        }
        return false;
    }

    public int GetEnemyHealth()
    {
        return health;
    }

    public void SetEnemyHealth(int newHealth)
    {
        health = newHealth;
    }

}
