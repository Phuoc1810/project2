using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTile : MonoBehaviour
{
    public float wartingDuration = 1.5f; //thoi gian truoc khi phat no
    public int damage = 20;

    //collider de kich hoat khi nguoi choi di vao pham vi
    private Collider2D explosiveCollider;
    //reference den camerashake
    private CameraShake cameraShake;
    private Cinemachine.CinemachineVirtualCamera virtualCamera;

    //tham chieu audio clip
    public AudioClip effectClip;
    void Start()
    {
        explosiveCollider = GetComponent<Collider2D>();
        explosiveCollider.enabled = false;
        if( explosiveCollider == null)
        {
            Debug.LogError("ExplosiveTile does not have a Collider2D component!");
        }
        else
        {
            explosiveCollider.isTrigger = true; 
        }

        //lay reference den cameraShake
        virtualCamera = GameObject.Find("Virtual Camera").GetComponent<Cinemachine.CinemachineVirtualCamera>();
        if( virtualCamera != null)
        {
            cameraShake = virtualCamera.GetComponent<CameraShake>(); //lay cameraShake tu Virtual Camera
            if(cameraShake == null)
            {
                Debug.LogError("Cinemachine Virtual Camera does not have CameraShake component");
            }
        }
        else
        {
            Debug.LogError("Cinemachine Virtual Camera not Found!");
        }
    }
    public void Initialize(Vector3 spawmPosition)
    {
        transform.position = spawmPosition; //dat o vuong tai vi tri spawm
        Invoke(nameof(ActivateTrigger), 0.32f);// delay 0.32s truoc khi gay damage
        AudioManager.instance.PlayOneShotAudio(effectClip); //goi effect
        Invoke(nameof(Explode), wartingDuration); //hen gio phat no

        
    }
    private void Explode()
    {
        //goi hieu ung rung lac khi phat no
        if(cameraShake != null)
        {
            cameraShake.Shake();
        }
        Destroy(gameObject); //xoa o vuong sau khi phat no

    }
    private void ActivateTrigger()
    {
        explosiveCollider.enabled = true; //kich hoat va cham sau khi delay
        Debug.Log("Trigger is active");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //chi kiem tra va cham khi vien gach duoc kich hoat
        if (!explosiveCollider.enabled)
        {
            return;
        }
        if (collision.CompareTag("Player"))
        {
            var playerStats = collision.GetComponent<playersat>();
            if (playerStats != null)
            {
                playerStats.currenthp -= Mathf.Max(damage - playerStats.defent, 0);//sat thuong co tinh phong thu
                if (playerStats.currenthp <= 0)
                {
                    Debug.Log("Player is defeated!");
                }
            }
        }
    }
    //hien thi pham vi vu no trong Unity Editor chi dung de debug
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
