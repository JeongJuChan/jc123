using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{

    private static UImanager m_UIinstance;

    
    public Text slidText;
    public Text comboText;
    public Text CoinText;
    public GameObject nextButton;
    public GameObject restartButton;

    public PlayerMovement playerMovement;

    int activeSceneIndex;

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

    private void Start() {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void offText()
    {
        slidText.enabled = false;
    }

    public void NextButton()
    {
        SceneManager.LoadScene(activeSceneIndex + 1);
        nextButton.SetActive(false);
    }

    public void RestartButton()
    {
       SceneManager.LoadScene(activeSceneIndex);
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
        CoinText.text = "X " + coin.ToString();
    }

}
