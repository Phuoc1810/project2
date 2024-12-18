using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawmPoint : MonoBehaviour
{
    public GameObject playerPerfab;
    // Start is called before the first frame update
    void Start()
    {
        //tim diem spawm dua tren ten spawm point 
        SpawmPoint[] spawmPoint = FindObjectsOfType<SpawmPoint>();
        bool spawmFound = false;

        foreach(SpawmPoint spawm in spawmPoint)
        {
            //kiem tra ten spawm point khop voi target spawm point 
            if (spawm.spawmPointName == SpawmPointManager.instance.targetSpawmPoint)
            {
                //kiem tra xem player da ton tai chua 
                GameObject player = GameObject.FindWithTag("Player");
                if (player == null)
                {
                    //neu khong tim thay player tao moi tu perfab
                    player = Instantiate(playerPerfab);
                }
                //dat vi tri player tai spawm point
                player.transform.position = spawm.transform.position;
                spawmFound = true;
                break;
            }
        }
        if(!spawmFound)
        {
            Debug.Log("Khong tim thay spawm point phu hop");
        }
    }
}
