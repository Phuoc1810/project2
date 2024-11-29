using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera bossCamera;
    public Animator bossAnimator;
    public float cameraDuration = 3f;// thoi gian camera tap trung vao boss

    private bool bossStarted = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") & !bossStarted)
        {
            bossStarted = true;
            StartCoroutine(StartBossSequence());
        }
    }
    IEnumerator StartBossSequence()
    {
        //kich hoat camera
        bossCamera.Priority = 20;
        //chay animation start cua boss
        bossAnimator.SetTrigger("Start");

        //cho thoi gian camera gui focus
        yield return new WaitForSeconds(cameraDuration);

        bossCamera.Priority = 5; //chuyen camera ve nguoi choi
        //chuyen boss sang trang thai idle
        bossAnimator.SetTrigger("Indle");
    }
}
