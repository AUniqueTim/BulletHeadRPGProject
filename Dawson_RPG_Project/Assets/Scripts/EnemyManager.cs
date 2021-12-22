using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour

    
{
    //Transforms
    [SerializeField] private Transform enemyTransformParent;
    [SerializeField] private Transform enemySpawnPos;
    [SerializeField] private GameObject currentEnemy;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private int nBenemies;
    public int enemyDamageModifier;

    public GameObject enemyClone;


    private void Awake()
    {
        if (enemySpawnPos != null)
        {
           enemyClone = Instantiate(enemy[Random.Range(0, enemy.Length)], enemySpawnPos.position, enemySpawnPos.rotation, enemyTransformParent);
        }
        currentEnemy = enemyClone;
    }

    private void Update()
    {
        
    }
    public void EnemyAttack()
    {

    }
    public void EnemyDrink()
    {

    }
}
