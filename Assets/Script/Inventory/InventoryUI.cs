using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Text keysTexts;
    // Start is called before the first frame update
    void Start()
    {
        //lien ket UI inventory den KeyManager khi vao scene
        if(KeyManager.instance != null)
        {
            KeyManager.instance.SetKeyTexts(keysTexts);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
