using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class cong : MonoBehaviour
{
    [SerializeField] private string fromscene;
    [SerializeField] private string toscene;



    void Start()
    {
        if (player._instance != null && player._instance.namescene == fromscene && player._instance.lastscene == toscene)
        {
            player._instance.transform.position = transform.position + Vector3.one;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            SceneManager.LoadScene(toscene);
            player._instance.namescene = toscene;
            player._instance.lastscene = fromscene;
        }
    }
}
