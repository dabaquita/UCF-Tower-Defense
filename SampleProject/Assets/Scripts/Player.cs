using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Health;
    public int startingHealth = 100;

    public static int Money;
    public int startingMoney = 300;

    // Start is called before the first frame update
    void Start()
    {
        Health = startingHealth;
        Money = startingMoney;
    }

}
