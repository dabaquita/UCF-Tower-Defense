using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int Health;
    public int startingHealth = 100;

    public static int Money;
    public int startingMoney = 300;

    private static int level;
    private int startingLevel = 0;

    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        Health = startingHealth;
        Money = startingMoney;
        level = startingLevel;
        healthText.text = Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Health.ToString();
    }

    public int getHealth()
    {
        return Health;
    }

    public int getLevel()
    {
        return level;
    }

    public int getMoney()
    {
        return Money;
    }

    public void setHealth(int newHealth)
    {
        Health = newHealth;
    }

    public void setLevel(int newHealth)
    {
        level = newHealth;
    }

    public void setMoney(int newMoney)
    {
        Money = newMoney;
    }
}