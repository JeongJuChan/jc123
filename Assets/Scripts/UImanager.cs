﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{

    private static UImanager m_UIinstance;

    
    public Text slidText;
    public Text comboText;
    public Text CoinText;
    public GameObject restartButton;
    public GameObject nextButton;
    
    public Button pauseButton;
    public GameObject StopPanel;

    public static UImanager instance
    {
        get
        {
            if(m_UIinstance == null)
            {
                m_UIinstance = FindObjectOfType<UImanager>();
            }
            return m_UIinstance;
        }
    }
    private void Awake() {
        UImanager[] uiManager = FindObjectsOfType<UImanager>();
        if (uiManager.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    
    public void offText()
    {
        slidText.enabled = false;
    }

    public void RestartButton()
    {
       Gamemanager.instance.SceneLoadManager(0);
       Time.timeScale = 1f;
       slidText.enabled = true;
       nextButton.SetActive(false);
       restartButton.SetActive(false);
       StopPanel.SetActive(false);
    }

    public void NextButton()
    {
        Gamemanager.instance.SceneLoadManager(1);
        slidText.enabled = true;
        nextButton.SetActive(false);
        restartButton.SetActive(false);
    }

    public void ComboUI(int count)
    {
        comboText.text = "Combo " + count.ToString();
        StartCoroutine(WaitComboText());
    }
    
    IEnumerator WaitComboText()
    {
        comboText.enabled = true;
        yield return new WaitForSeconds(1f);
        UImanager.instance.comboText.enabled = false;
    }

    public void CoinUI(int coin)
    {
        CoinText.text = "X" + coin.ToString();
    }

    public void PauseButton()
    {
        pauseButton.gameObject.SetActive(false);
        StopPanel.SetActive(true);

        Time.timeScale = 0f;

    }
    public void PlayButton()
    {
        pauseButton.gameObject.SetActive(true);
        StopPanel.SetActive(false);

        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    

    

}
