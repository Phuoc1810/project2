using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullethitbox : MonoBehaviour
{
   
    public Animator anim;
        private void Start()
    {
        anim = GetComponent<Animator>();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
            anim.SetTrigger("expositon");
        else if(collision.CompareTag("Player"))
        {
            anim.SetTrigger("expositon");
          
            
        }
    }
    public void expositon()
    {
        Destroy(this.gameObject);
    }
    
}
