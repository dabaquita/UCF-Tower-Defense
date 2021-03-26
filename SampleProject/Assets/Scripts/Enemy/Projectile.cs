using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum projectileType
{
    scissors, pen, stapler, poo, lime, fireball, sword, bagel, fry
};

public class Projectile : MonoBehaviour
{
    [SerializeField] int attackDamage;
    [SerializeField] projectileType pType;

    private void Start()
    {
        Destroy(gameObject, 0.7f);
    }
    
    

    public int AttackDamage
    {
        get
        {
            return attackDamage;
        }
    }

    public projectileType PType
    {
        get
        {
            return pType;
        }
    }

}
