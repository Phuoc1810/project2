
    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class takedamge : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fire"))
        {
            beingattack();

        }
    }
    void beingattack()
    {
        var firedamge = 20;
        var playerdef = player._instance.GetComponent<playersat>().defent;//chi so phong thu cua player
        var damage = firedamge - playerdef;//can bang game
        if (damage < 0) damage = 0;
        player._instance.GetComponent<playersat>().currenthp -= damage;
       
    }
}

