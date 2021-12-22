using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitsScene1 : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;
    
    public int maxHP;
    public int currentHP;


    private void Awake()
    {
        maxHP = 100;
        currentHP = 90;
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
            return true; //Unit Died
        else
            return false; //Unit Survived
    }
    

}


