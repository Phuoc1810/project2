using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfollowbat : MonoBehaviour
{
 
    public float speed;
    public float lineOfSite = 2f;
    public int count = 0;
    public Transform player;
    public Rigidbody rb;
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {

        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineOfSite)
        {
            
            count += 1;
            if (count == 1)
            {
                anim.SetTrigger("wakeup");
                lineOfSite *= 2;
                
            }
            anim.SetTrigger("walk");
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            anim.SetTrigger("indel");
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
