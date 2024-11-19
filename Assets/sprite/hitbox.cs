using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy"))
        {
            Enemy enemyheath;
            enemyheath =collision.gameObject.GetComponent<Enemy>();
            enemyheath.takedamage(2);
            
        }
    }
}
