using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;

    //tao mot reference den AudioSource
    private AudioSource audioSource;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else Destroy(gameObject);
    }

    //phat effect 
    public void PlayOneShotAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
