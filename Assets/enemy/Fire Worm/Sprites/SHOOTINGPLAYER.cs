using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SHOOTINGPLAYER : MonoBehaviour
{
    public float speed;
    public float lineOfSite = 2f;
    public int count = 0;
    public float shootingranger;
    public Transform player;
    public GameObject bullet;
    public GameObject buttetparent;
    public Animator anim;
    public float firerate = 2f;
    public float nextfiretime;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineOfSite && distancefromplayer>shootingranger)
        {
          
           anim.SetTrigger("WALK");
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if(distancefromplayer <= shootingranger && nextfiretime< Time.time)
       {
            anim.SetTrigger("shoot");
            bullet.transform.localScale = transform.localScale;
            Instantiate(bullet, buttetparent.transform.position, Quaternion.identity);
            nextfiretime = Time.time + firerate;
            
        }
        else
            anim.SetTrigger("INDEL");

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingranger);
    }
}
