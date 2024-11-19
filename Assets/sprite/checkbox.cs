using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class checkbox : MonoBehaviour
{
    [SerializeField] Transform groundcheckbox;
    [SerializeField] LayerMask ground;
    public bool groundcheck;
    public bool isground;
    Vector2 center;
    Vector2 size;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        center = groundcheckbox.position;
        size = new Vector2(0.6f, 0.5f);
        groundcheck = Physics2D.OverlapBox(center, size,0, ground);
    
    }
   
}
