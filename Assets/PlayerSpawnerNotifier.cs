using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerNotifier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Thong bao cho tat ca cac AIDestinationSetter rang Player da xuat hien
        AIDestinationSetter[] enemies = FindObjectsOfType<AIDestinationSetter>();
        foreach(AIDestinationSetter enemy in enemies)
        {
            enemy.SetTarget(transform); //gan player lam target 
        }
    }
}
