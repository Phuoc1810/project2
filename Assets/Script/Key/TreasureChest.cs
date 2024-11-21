using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public int landIndex; //Vung dat ma ruong nay thuoc ve
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
            KeyManager.instance.AddKey(landIndex);
            Debug.Log("Da nhan Key");
            chestAnimator.SetTrigger("Openchest");
            Destroy(gameObject, 2);
        }
    }
}
