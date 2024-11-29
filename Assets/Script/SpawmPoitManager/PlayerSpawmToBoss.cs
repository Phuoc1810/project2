using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawmToBoss : MonoBehaviour
{
    public static PlayerSpawmToBoss Instance;
    public string spawmPointName;// Ten diem spawm ma player se xuat hien
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        MovePlayerToSpawmPoint();
    }
    private void MovePlayerToSpawmPoint()
    {
        if(!string.IsNullOrEmpty(spawmPointName))
        {
            GameObject spawmPoint = GameObject.Find(spawmPointName); //tim diem spawm theo ten
            if(spawmPoint != null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    player.transform.position = spawmPoint.transform.position;
                }
            }
            else
            {
                Debug.LogWarning("Spawm point not found! "+ spawmPointName);
            }
        }
    }
}
