using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform playerPos;
    [SerializeField] private int enemyDetectionDistance;
    [SerializeField] private int moveDistance;
    public GameObject enemyGO;
    public int enemyMaxHP;
    public int enemyCurrentHP;



    //Enemy Player Detection/Attack

    [SerializeField] private int enemySpeed;

    public void Update()
    {
        if (playerPos != null)
        {
            if (playerPos.position.x - transform.position.x <= enemyDetectionDistance)
            {
                EnemyAttack();
            }
        }

        
    }

    //Enemy take damage from bullet

    //Enemy damage BH on collision

    public void EnemyAttack()
    {
        gameObject.transform.Translate(Vector3.right * enemySpeed * Time.deltaTime); ;

    }
}
