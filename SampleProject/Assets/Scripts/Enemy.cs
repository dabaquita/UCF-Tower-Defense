using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int Health;
    public int startingHealth = 50;

    // for testing
    Vector3 endOfMap;

    // Start is called before the first frame update
    void Start()
    {
        Health = startingHealth;
        transform.position = endOfMap;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead())
        {
            destroyEnemy();
        }

        // will be true when the enemy hits the end of the map while still having health
        // using 3 since the array in Path.cs only has 4 segments and I assume that's the last
        // one
        if (transform.position.Equals(endOfMap))
        {
            damagePlayer();
        }
    }

    void damagePlayer()
    {
        Player.Health -= 10;
        destroyEnemy();
    }

    private bool isDead()
    {
        if (Health <= 0)
        {
            return true;
        }
        return false;
    }

    private void destroyEnemy()
    {
        Destroy(gameObject);
    }
}
