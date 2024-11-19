using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takedamge2 : MonoBehaviour
{
    void hurt()
    {
        var firedamge = 20;
        var playerdef = player._instance.GetComponent<playersat>().defent;//chi so phong thu cua player
        var damage = firedamge - playerdef;//can bang game
        if (damage < 0) damage = 0;
        player._instance.GetComponent<playersat>().currenthp -= damage;

    }
}
