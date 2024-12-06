﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject explosiveTilePerfab; // tham chieu den vien gach
    public Animator animator;
    public float tileSpawmInterval = 0.5f; // khoan thoi gian giua cac lan spawm o vuong
    public int numberOfTile = 8; // so o vuong xuat hien sau moi dot tan cong
    private Transform playerTransform; // vi tri cua nguoi choi
    public float timeStart = 2.5f; // thoi gian de boss bat dau tan cong
    private Vector3 currentDirection; // huong di chuyen cua chuoi gach

    //quan li chi so boss
    public int maxHeal = 200;
    private int currentHeal; //mau hien tai
    public GameObject specialSkill; //ki nang dac biet

    //tham chieu den sprite nguoi choi
    private playersat playerStart;

    //bien kiem tra su dung skill dac biet
    private bool isSpecialSkillColdDown = false;
    //quan li trang thai tan cong
    private bool isAttacking = true;
    void Start()
    {
        currentHeal = maxHeal; //khoi tao mau cua boss

        specialSkill.SetActive(false);
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform; // gan transform cua Player vao bien player
            playerStart = player.GetComponent<playersat>(); //lay component chi so cua player
            if(playerStart == null)
            {
                Debug.LogError("Player does not have 'playersat' component");
            }
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
        StartCoroutine(SpawmTiles());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage();
        }
    }
    private IEnumerator SpawmTiles()
    {
        Debug.Log("Starting to spawn tiles...");

        while (isAttacking)
        {
            yield return new WaitForSeconds(1); // thoi gian cho tuong ung vo animation tan cong

            animator.SetTrigger("Attack1");

            // lay vi tri hien tai cua player la diem bat dau
            currentDirection = (playerTransform.position - transform.position).normalized; // huong mac dinh cua vien gach

            float spacing = 1.5f; // khoang cach giua cac vien gach
            Vector3 lastTilePosition = playerTransform.position; // vi tri ban dau la vi tri player

            for (int i = 0; i < numberOfTile; i++)
            {
                // tinh toan vi tri moi (tinh theo vi tri cuoi cùng, không phải vị trí người chơi)
                Vector3 tilePosition = lastTilePosition + currentDirection * spacing;

                // tạo viên gạch tại vị trí tính toán
                if (playerTransform != null)
                {
                    Debug.Log("Spawning tile");
                    GameObject tile = Instantiate(explosiveTilePerfab, tilePosition, Quaternion.identity);
                    tile.GetComponent<ExplosiveTile>().Initialize(playerTransform.position);
                }
                // cho truoc khi tao o vuong tiep theo
                yield return new WaitForSeconds(tileSpawmInterval);
            }
            animator.SetTrigger("Indle");
            yield return new WaitForSeconds(3); //dot tan con tiep theo
        }
    }
    //ham giam mau cua boss
    public void TakeDamage()
    {
        if (playerStart == null) return; // dam bao playerStarts khong null
        //tinh sat thuong dua tren chi so choi cua nguoi choi
        int damage = (int)playerStart.attack;
        currentHeal -= damage; //giam mau cua boss
        Debug.Log($"Boss current health: {currentHeal}");

        //kich hoat ki nang dac biet khi mau <= 30%
        if(currentHeal <= maxHeal * 0.3 && !isSpecialSkillColdDown && specialSkill != null && !specialSkill.activeSelf)
        {
            StartCoroutine(ActivateSpecialSkill());
            specialSkill.SetActive(false);
        }

        //kiem tra neu mau <= 0
        if(currentHeal <= 0)
        {
            Die();
        }
    }

    //goi special skill
    private IEnumerator ActivateSpecialSkill()
    {
        specialSkill.SetActive(true);
        Debug.Log("special skill is active");
        yield return new WaitForSeconds(0.4f);
        specialSkill.SetActive(false);

        isSpecialSkillColdDown = true;
        yield return new WaitForSeconds(5);
        isSpecialSkillColdDown = false;
    }
    //xu li logic khi boss chet
    private void Die()
    {
        isAttacking = false;
        Debug.Log("boss defeated!");
        StopAllCoroutines(); //dung tat ca cac coroutine dang chay
        //cho doi cho den khi Die hoan thanh
        StartCoroutine(WaitForDeathAnimation());
    }
    private IEnumerator WaitForDeathAnimation()
    {
        //doi cho den khi aniamtion die hoan thanh
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(6);
        // huy doi tuong 
        Destroy(gameObject);
    }
}
