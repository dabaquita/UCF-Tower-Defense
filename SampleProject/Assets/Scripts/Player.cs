using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private static int health;
    private const int START_HEALTH = 100;

    private static int money;
    private const int START_MONEY = 300;

    public static int level;
    public int START_LEVEL = 0;

    public Text healthText;
    public Text moneyText;

    public GameObject levelBlockSpinScooter;

    // Start is called before the first frame update
    void Start()
    {
        health = START_HEALTH;
        money = START_MONEY;
        level = START_LEVEL;
        healthText.text = health.ToString();
        moneyText.text = money.ToString();

        if (level >= 3)
        {
            levelBlockSpinScooter.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
        moneyText.text = money.ToString();
    }

    public int Bank
    {
        get
        {
            return money;
        }
    }

    public void setBank(int newTotal)
    {
        setMoney(newTotal);
    }

    // For Unit Tests
    public static int getHealth()
    {
        return health;
    }

    public static int getLevel()
    {
        return level;
    }

    public static int getMoney()
    {
        return money;
    }

    public static void setHealth(int newHealth)
    {
        health = newHealth;
    }

    public static void setLevel(int newHealth)
    {
        level = newHealth;
    }

    public static void setMoney(int newMoney)
    {
        money = newMoney;
    }
}