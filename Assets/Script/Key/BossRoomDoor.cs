using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRoomDoor : MonoBehaviour
{
    public string bossRoomSceneName;
    public string pointToBoss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (KeyManager.instance.HasAllKeys())
            {
                //luu ten diem spawm de su dung trong phong boss
                PlayerSpawmToBoss.Instance.pointToBoss = pointToBoss;
                Debug.Log("Spawn point name set to: " + pointToBoss);
                //neu du chia khoa chuyen den phong boss
                UnityEngine.SceneManagement.SceneManager.LoadScene(bossRoomSceneName);
            }
        }
    }
}
