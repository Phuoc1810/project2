using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletrb;
    private void Start()
    {
        
        bulletrb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 movedir = (target.transform.position - transform.position).normalized * speed;
        bulletrb.velocity = new Vector2(movedir.x, movedir.y);
        Destroy(this.gameObject, 2);
    }
}
