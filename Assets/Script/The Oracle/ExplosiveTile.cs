using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTile : MonoBehaviour
{
    public float wartingDuration = 1.5f; //thoi gian truoc khi phat no
    public int damage = 20;

    //collider de kich hoat khi nguoi choi di vao pham vi
    private Collider2D explosiveCollider;

    void Start()
    {
        explosiveCollider = GetComponent<Collider2D>();
        if( explosiveCollider == null)
        {
            Debug.LogError("ExplosiveTile does not have a Collider2D component!");
        }
        else
        {
            explosiveCollider.isTrigger = true; 
        }
    }
    public void Initialize(Vector3 spawmPosition)
    {
        transform.position = spawmPosition; //dat o vuong tai vi tri spawm
        Invoke(nameof(Explode), wartingDuration); //hen gio phat no
    }

    //xu li vu no 
    private void Explode()
    {
        Destroy(gameObject); //xoa o vuong sau khi phat no
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerStats = collision.GetComponent<playersat>();
            if (playerStats != null)
            {
                playerStats.currenthp -= Mathf.Max(damage - playerStats.defent, 0);//sat thuong co tinh phong thu
                if (playerStats.currenthp <= 0)
                {
                    Debug.Log("Player is defeated!");
                }
            }
        }
    }
    //hien thi pham vi vu no trong Unity Editor chi dung de debug
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
