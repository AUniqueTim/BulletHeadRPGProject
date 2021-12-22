using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bulletSpriteRenderer;

    public Unit enemyUnit;
    public Unit playerUnit;

    public int bulletDamage;

    public Enemy enemy;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Damage Unit on collision
        //Toolbox.Instance.m_Unit.TakeDamage(Toolbox.Instance.m_Unit.damage);

        //Particle effect
        //Sound

        

        if (collision.gameObject.tag == "EvilSquirrel")
        {
            enemy.enemyCurrentHP -= bulletDamage;

            if ( enemy.enemyCurrentHP <= 0)
            {
                bool enemyDied = true;

                if (enemyDied)
                {
                    collision.gameObject.SetActive(false);
                }
                else
                {
                    enemyDied = false;
                }
            }
        }

        Destroy(gameObject);
    }
    private void Update()
    {
        if (PlayerMovement.Instance.flipX == true) { bulletSpriteRenderer.flipX = false; }
        else if (PlayerMovement.Instance.flipX == false) { bulletSpriteRenderer.flipX = true; }
    }


}
