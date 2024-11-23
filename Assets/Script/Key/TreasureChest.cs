using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    
    private bool isOpen = false;

    private Animator chestAnimator;
    private void Start()
    {
        chestAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isOpen)
        {
            isOpen = true;
            KeyManager.instance.AddKey();
            OpenChest();
            Debug.Log("Nguoi choi da nhan duoc key tu vung dat");
            Destroy(gameObject, 2);
        }
    }
    private void OpenChest()
    {
        if(chestAnimator != null)
        {
            chestAnimator.SetTrigger("Openchest");
        }
    }
}
