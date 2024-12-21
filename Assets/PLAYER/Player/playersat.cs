using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersat : MonoBehaviour
{
    [Header("stat")]
    public float maxhp = 100;
    public float currenthp = 100;

    public float maxmp = 100;
    public float currentmp = 100;

    public float defent = 10;
    public float attack = 10;
    [Header("lever")]
    public int level = 1;

    public float currentexp = 0;
    public float[] nextexp;
    // tg hoi phuc mana va hp
    public float hprecoverytime = 5f;
    public float mprecoverytime = 1f;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        nextexp = new float[10];
        nextexp[0] = 100;
        for (int i = 1; i < 10; i++)
        {
            nextexp[i] = Mathf.Floor(nextexp[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthp < maxhp)
        {
            hprecoverytime -= Time.deltaTime;
            if (hprecoverytime <= 0)
            {
                currenthp += 1;
                hprecoverytime = 5f;
            }
        }
        if (currentmp < maxmp)
        {
            mprecoverytime -= Time.deltaTime;
            if (mprecoverytime <= 0)
            {
                currentmp += 1;
                mprecoverytime = 1f;
            }
        }

    }
    void levelup()
    {
        level++;
        currentexp = 0;
        maxhp += 50;
        currenthp = maxhp;
        maxmp += 50;
        currentmp = maxmp;
        defent += 5;
        attack += 5;

    }
    public void expcong(int exp)
    {
        currentexp += exp;
        if (currentexp >= nextexp[level - 1])
        {
            levelup();
        }
    }
    public void hurtss()
    {
        anim.SetTrigger("hurt");
        var firedamge = 20;
        var playerdef = player._instance.GetComponent<playersat>().defent;//chi so phong thu cua player
        var damage = firedamge - playerdef;//can bang game
        if (damage < 0) damage = 0;
        player._instance.GetComponent<playersat>().currenthp -= damage;

    }
}

