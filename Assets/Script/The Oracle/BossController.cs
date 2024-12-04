using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Animator animator;
    public TitleManager tileManager; //quan li vien gach
    private Transform playerTransform; // vi tri cua nguoi choi
    public float timeStart = 2.5f; // thoi gian de boss bat dau tan cong
    public float spawmDelay = 0f; //thoi gian cho truoc khi spawm gach

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform; // gan transform cua Player vao bien player
        }
        else
        {
            Debug.LogError("Dont Find game object with tag 'Player' !");
        }
        StartAttackSequence();
    }

    public void StartAttackSequence()
    {
        Debug.Log("Attack sequence started");
        StartCoroutine(BossStart());
    }

    private IEnumerator BossStart()
    {
        yield return new WaitForSeconds(timeStart);
        StartCoroutine(BossAttackRoutine());
    }

    private IEnumerator BossAttackRoutine()
    {
        yield return new WaitForSeconds(timeStart);

        while (true)
        {
            yield return new WaitForSeconds(spawmDelay);
            animator.SetTrigger("Attack1");

            //spawm xung quanh nguoi choi
            if (tileManager != null && playerTransform != null)
            {
                tileManager.SpawnTiles(transform.position, playerTransform.position);
            }
            animator.SetTrigger("Indle");

            yield return new WaitForSeconds(3);
        }
    }
}
