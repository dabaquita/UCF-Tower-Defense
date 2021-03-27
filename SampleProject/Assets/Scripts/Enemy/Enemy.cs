using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int moneyAwarded = 50;
    [SerializeField] float speed = 5;
    [SerializeField] int damageDealt = 1;
    [SerializeField] int difficultyValue;

    public PathCreator pathCreator;
    float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        pathCreator = GameObject.Find("EnemyPath").GetComponent<PathCreator>();
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

        else if (IsAtEnd())
        {
            DamagePlayer();
            gm.UnRegisterEnemy(this);
            //DestroyEnemy();
        }
    }

    // When a projectile collides with an enemy, destroy the projectile
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            Debug.Log("Projectile Collision: " + health);
            Projectile newP = collision.gameObject.GetComponent<Projectile>();
            if( newP != null)
            {
                DamageEnemy(newP.AttackDamage);
                Destroy(collision.gameObject);
            }
        }
    }

    public void DamagePlayer()
    {
        Player.setHealth(Player.getHealth() - damageDealt);
    }

    public bool IsDead()
    {
        if (health <= 0)
        {
            Player.setMoney(Player.getMoney() + moneyAwarded);
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

    public void DamageEnemy(int damage)
    {
        health -= damage;
    }

    public void SetSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    public int GetDifficltyValue()
    {
        return difficultyValue;
    }
}
