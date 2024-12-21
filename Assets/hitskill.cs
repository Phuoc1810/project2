using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitskill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Enemy enemyheath;
            enemyheath = collision.gameObject.GetComponent<Enemy>();
            enemyheath.takedamage(4);

        }
        else if (collision.CompareTag("enemy2"))
        {
            enemynoastar enemyheath;
            enemyheath = collision.gameObject.GetComponent<enemynoastar>();
            enemyheath.takedamage(4);

        }
        //tan cong boss 
        if (collision.CompareTag("Boss"))
        {
            BossController boss = collision.GetComponent<BossController>();
            if (boss != null)
            {
                boss.TakeDamage(); //Goi ham take damage
            }
        }
    }
}
