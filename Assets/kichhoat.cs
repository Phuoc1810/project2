using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kichhoat : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            
            
                for(int i=0;i<=enemy.Length;i++)
            {
                enemy[i].gameObject.SetActive(true);
            }
            

        }
    }
}
