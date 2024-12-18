using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomSpawm : MonoBehaviour
{
    public GameObject playerPerfab;
    public Transform[] spawmpoints; //danh sach cac spawm point co the co trong phong boss

    // Start is called before the first frame update
    void Start()
    {
        //kiem tra thong tin tu playerbossspawmmanager
        if(PlayerBossSpawmManager.Instance == null || string.IsNullOrEmpty(PlayerBossSpawmManager.Instance.spawm_Point_Name))
        {
            Debug.LogError("PlayerBossSpawnManager is null or spawn point name is empty!");
            return; 
        }

        string targetSpawmPointName = PlayerBossSpawmManager.Instance.spawm_Point_Name;
        Debug.Log("Target spawn point: " + targetSpawmPointName);
        //tim spawm point dua theo ten
        Transform targetSpawmPoint = null;
        foreach(Transform spawmpoint in spawmpoints)
        {
            if(spawmpoint.name == targetSpawmPointName)
            {
                targetSpawmPoint = spawmpoint;
                Debug.Log("Checking spawn point: " + spawmpoint.name);
                break;
            }
        }
        if(targetSpawmPoint != null)
        {
            //spawm player tai vi tri duoc chi dinh
            GameObject player = GameObject.FindWithTag("Player");
            if(player == null) // neu chua co player, tao moi
            {
                player =  Instantiate(playerPerfab, targetSpawmPoint.position, Quaternion.identity);
            }
            else //neu da co player, di chuyen den spawm
            {
                player.transform.position = targetSpawmPoint.position;
            }
        }
        else
        {
            Debug.LogError("Target spawm point not found: " + targetSpawmPointName);
        }
    }
}
