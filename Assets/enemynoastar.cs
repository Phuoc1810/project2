using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemynoastar : MonoBehaviour
{
    public int health;

 
    private Animator anim;
    public Transform enemymove;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void takedamage(int damge)
    {
        if (transform.localScale.x == -1f)
            enemymove.position = new Vector2(enemymove.position.x + 0.5f, enemymove.position.y);
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
