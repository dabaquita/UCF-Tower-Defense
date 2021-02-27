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

    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        Health = startingHealth;
        Money = startingMoney;
        healthText.text = Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Health.ToString();
    }
}