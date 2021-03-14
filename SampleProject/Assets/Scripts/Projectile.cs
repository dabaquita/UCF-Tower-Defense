using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum projectileType
{
    scissors, pen, stapler
};

public class Projectile : MonoBehaviour
{
    [SerializeField] int attackDamage;
    [SerializeField] projectileType pType;

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
