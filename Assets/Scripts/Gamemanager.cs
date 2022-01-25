﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager m_instance;
    bool stopping;
    
    // 시간정지 정수부
    public float stopTime;
    public float slowTime;

    public bool isDead;

    public Animator playerAnim;

    public CinemachineFramingTransposer cam;

    public int count;

    private void Awake() 
    {
        isDead = false;
        cam = FindObjectOfType<CinemachineFramingTransposer>();
    }

    public static Gamemanager instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<Gamemanager>();
            }
            return m_instance;
        }
        
    }


    public void TimeStop()
    {
        if(!stopping)
        {
            stopping = true;
            Time.timeScale = 0f;

            StartCoroutine("Stop");

        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSecondsRealtime(stopTime);
        Time.timeScale = 0.5f;

        yield return new WaitForSecondsRealtime(slowTime);
        Time.timeScale = 1f;
        stopping = false;
    }

    public void Win()
    {
        playerAnim.SetBool("win", true);
        // 그 외 UI 추후에는 에너미 우는 것 등
    }

    public void Combo() 
    {
        if (!playerAnim.GetBool("isJump")) count++;
    }
}
