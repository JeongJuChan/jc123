using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{

    private static UImanager m_UIinstance;

    
    public  Text slidText;
    public  Text comboText;
    public Button button;

    public PlayerMovement playerMovement;

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

    public void offText()
    {
        slidText.enabled = false;

    }

    public void NextButton()
    {
        playerMovement.StartPoint();
        slidText.enabled = true;
    }

    public void RestartButton()
    {

       SceneManager.LoadScene(0);

    }



}
