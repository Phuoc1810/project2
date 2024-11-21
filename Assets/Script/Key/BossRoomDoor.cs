using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRoomDoor : MonoBehaviour
{
    public int landIndex; //vung dat ma phong nay thuoc ve
    public string bossRoomSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (KeyManager.instance.HasAllKeys(landIndex))
            {
                //neu du chia khoa chuyen den phong boss
                SceneManager.LoadScene(bossRoomSceneName);
            }
        }
    }
}
