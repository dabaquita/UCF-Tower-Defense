using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using PathCreation;

public class Enemy : MonoBehaviour
{
    public int Health;
    public static int startingHealth = 50;

    // public pathCreator pathCreator;
    // public float speed = 5;
    // float distanceTravelled;


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

        // distanceTravelled += speed * Time.deltaTime;
        // transform.position = pathCreator.path.getPointAtDistance(distanceTravelled);


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
