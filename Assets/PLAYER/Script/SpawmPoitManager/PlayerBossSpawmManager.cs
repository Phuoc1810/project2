using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossSpawmManager : MonoBehaviour
{
    public static PlayerBossSpawmManager Instance; //singleton de quan ly object nay
    public string spawm_Point_Name; //ten spawm point ma player se xuat hien

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
