using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMove : MonoBehaviour
{
    AudioSource audioSource;
    Animator anim;
    public Collider punchCollider;

    public Transform exitWallTrans;

    Touch touch;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.applyRootMotion = true;
    }



    void Update()
    {
        if (Vector3.Distance(transform.position, exitWallTrans.position) > 4f)
        {
            anim.SetTrigger("run");
        }
        else
        {
            anim.SetBool("final", true);
            Gamemanager.instance.cam.m_CameraDistance = 15f;
        }
            
        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // if (anim.GetBool("punch")) return;
                anim.SetTrigger("punch");
                float hitRandom = Random.Range(0f, 1f);
                anim.SetFloat("fist", hitRandom);
            }
        }
    }

    IEnumerator Punch()
    {
        punchCollider.enabled = true;
        yield return new WaitForSeconds(0.05f);
        punchCollider.enabled = false;
    }
    
    public void Strike()
    {
        StartCoroutine(Punch());

        AudioClip audio = (AudioClip)Resources.Load("hit01");
        audioSource.clip = (AudioClip)audio;
        audioSource.Play();
    }
    
}
