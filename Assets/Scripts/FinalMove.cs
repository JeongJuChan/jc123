using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMove : MonoBehaviour
{
    AudioSource audioSource;
    Animator anim;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    public void Strike()
    {
        AudioClip audio = (AudioClip)Resources.Load("hit01");
        audioSource.clip = (AudioClip)audio;
        audioSource.Play();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float hitRandom = Random.Range(0f, 1f);
            anim.SetFloat("fist", hitRandom);
            anim.SetTrigger("punch");
        }
    }
    
}
