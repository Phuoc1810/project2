using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Enemy : MonoBehaviour
{
    public int health;

    public AIPath aipath;
    private Animator anim;
    public Transform enemymove;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aipath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
       
    }
    public void takedamage (int damge)
    {
        if(transform.localScale.x == -1f)
        enemymove.position = new Vector2(enemymove.position.x+0.5f,enemymove.position.y);
        if (transform.localScale.x == 1f)
            enemymove.position = new Vector2(enemymove.position.x - 0.5f, enemymove.position.y);
        anim.SetTrigger("hurt");
        health -= damge;
        if (health < 0)
        {
            anim.SetTrigger("die");
            
        }
        Debug.Log("takedamge");
    }
    public void die()
    {
        Destroy(gameObject);
    }
}
