using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawmToBoss : MonoBehaviour
{
    public static PlayerSpawmToBoss Instance;
    public string pointToBoss;// Ten diem spawm ma player se xuat hien
    private void Awake()
    {
        Debug.Log("PlayerSpawmToBoss instance created.");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Duplicate PlayerSpawmToBoss instance destroyed.");
            Destroy(gameObject);
        }
   }
    void Start()
    {
        Debug.Log("PlayerSpawmToBoss is running in scene: " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        MovePlayerToSpawmPoint();
    }
    private IEnumerator MovePlayerToSpawmPoint()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Checking Spawn Point: " + pointToBoss);
        if (!string.IsNullOrEmpty(pointToBoss))
        {
            GameObject spawmPoint = GameObject.Find(pointToBoss); //tim diem spawm theo ten
            if(spawmPoint != null)
            {
                GameObject player = GameObject.FindWithTag("Player");
                Debug.Log("Found Spawn Point: " + pointToBoss);
                if (player != null)
                {
                    Debug.Log("Player found, moving to: " + spawmPoint.transform.position);
                    player.transform.position = spawmPoint.transform.position;
                }
                else
                {
                    Debug.LogWarning("Player not found in scene!");
                }
            }
            else
            {
                Debug.LogWarning("Spawm point not found! "+ pointToBoss);
            }
        }
        else
        {
            Debug.LogWarning("Spawn Point Name is null or empty!");
        }
    }
}
