using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public GameObject notification_Perfab;
    private GameObject notification_Canvas;

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
            ShowNotification();
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
    private void ShowNotification()
    {
        //khoi tao panel thong bao tu perfab
        notification_Canvas = Instantiate(notification_Perfab);

        //dam bao canvas ton tai va hien thi dung
        if(notification_Canvas != null)
        {
            notification_Canvas.SetActive(true);//hien thi canvas
            Time.timeScale = 0;
            StartCoroutine(WaitForAnyToClose());//choi nguoi choi nhan nut bat ki
        }
    }
    private IEnumerator WaitForAnyToClose()
    {
        //nguoi choi nhan phim bat ki
        yield return new WaitUntil(() => Input.anyKeyDown);

        if(notification_Canvas != null)
        {
            Destroy(notification_Canvas); //xoa canvas
            Time.timeScale = 1;
        }
    }
}
