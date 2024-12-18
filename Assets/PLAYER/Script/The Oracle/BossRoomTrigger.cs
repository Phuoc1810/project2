using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BossRoomTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera bossCamera;
    public Animator bossAnimator;
    public float cameraDuration = 3f;// thoi gian camera tap trung vao boss
    public Transform bossTransform; //Transform cua boss de camera di chuyen den do
    public AudioClip bossClip; //effect boss start

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
        //kich hoat camera focus vao boss
        bossCamera.Priority = 20;

        //di chuyen camera tu player den boss (su dung coroutine de di chuyen dan)
        float elapsedTime = 0f;
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 startingPosition = playerTransform.position;
        Vector3 targetingPosition = bossTransform.position;

        //khoa truc z cua camera
        targetingPosition.z = bossCamera.transform.position.z;
        startingPosition.z = bossCamera.transform.position.z;

        // di chuyen camera tu player den boss trong thoi gian cameraDuration
        while(elapsedTime < cameraDuration)
        {
            // khong thay doi position cua camera, chi thay doi follow va LookAt
            float t = elapsedTime/cameraDuration;
            bossCamera.transform.position = Vector3.Lerp(startingPosition, targetingPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;  
        }
        
        //dam bao camera dung vi tri cua boss
        bossCamera.transform.position = targetingPosition;

        //chay animation bat dau cua boss sau khi di chuyen camera hoan tat
        bossAnimator.SetTrigger("Start");
        //cho thoi gian cho animation va camera tap trung vao boss
        AudioManager.instance.PlayOneShotAudio(bossClip); //goi effect
        yield return new WaitForSeconds(cameraDuration);
        //chuyen camera ve lai player
        bossCamera.Priority = 5;

        //chuyen boss sang trang thai indle
        bossAnimator.SetTrigger("Indle");
    }
}
