using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public static int startingHealth = 50;

    // for testing
    public static Vector3 endOfMap = new Vector3(1,2,3);

    // Start is called before the first frame update
    void Start()
    {
        Health = Enemy.startingHealth;
        transform.position = Enemy.endOfMap;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead())
        {
            DestroyEnemy();
        }

        // will be true when the enemy hits the end of the map while still having health
        // using 3 since the array in Path.cs only has 4 segments and I assume that's the last
        // one
        if (transform.position.Equals(endOfMap))
        {
            DamagePlayer();
        }
    }

    public void DamagePlayer()
    {
        Player.Health -= 10;
        // DestroyEnemy();
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
}
