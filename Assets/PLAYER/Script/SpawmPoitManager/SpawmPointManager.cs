using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmPointManager : MonoBehaviour
{
    public static SpawmPointManager instance;
    public string targetSpawmPoint;//Ten spawm point muc tieu

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
