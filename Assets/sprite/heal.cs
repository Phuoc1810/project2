using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class heal : MonoBehaviour
{
  [SerializeField]  private float startingheal;
  
  

    public float currentheal ;
    private Animator anim;
    private bool dead=false;
    [Header("components")]
    [SerializeField] private Behaviour[] components;
    [SerializeField] private AudioClip hurtsound;
    [SerializeField] private AudioClip diesound;

    private void Awake()
    {
        currentheal = startingheal;
        anim = GetComponent<Animator>();
    }
    public void takedamge(float _damge)
    {
       
        currentheal = Mathf.Clamp(currentheal - _damge, 0, startingheal);
        if(currentheal>0)
        {
           
            anim.SetTrigger("hurt");
            
        }
        else
        {
            if (!dead)
            {
               
                anim.SetTrigger("die");
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                dead = true;
                
}
        }
        
    }
    public void addheal(float _value)
    {
        currentheal = Mathf.Clamp(currentheal + _value, 0, startingheal);
    }
    public void healtake(float _heart)
    {
        currentheal = startingheal;
        currentheal += 1;
        startingheal += 1;
    }
    public bool checking()
    {
        return dead;
    }
    private void Update()
    {
        
    }
    public void Respawn()
    {
        dead = false;
        addheal(startingheal);
        anim.ResetTrigger("die");
        anim.Play("idel");
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
     
        
    }
}
