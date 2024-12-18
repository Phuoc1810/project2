using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string targetSceneName; //ten scene se load
    public string targetSpawmPointName;// Ten diem spawm trong scene muc tieu

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //luu ten spawm point vao quan li spawm
            SpawmPointManager.instance.targetSpawmPoint = targetSpawmPointName;

            SceneManager.LoadScene(targetSceneName);
        }
    }
}
