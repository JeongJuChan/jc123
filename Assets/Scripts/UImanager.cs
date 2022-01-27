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

    public Button playButton;
    public Button pauseButton;

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
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    
    public void offText()
    {
        slidText.enabled = false;
    }

    public void NextButton()
    {
        SceneManager.LoadScene(Gamemanager.instance.activeSceneIndex + 1);
        nextButton.SetActive(false);
    }

    public void RestartButton()
    {
       SceneManager.LoadScene(Gamemanager.instance.activeSceneIndex);
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

    public void PauseButton()
    {
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);

        Time.timeScale = 0f;

    }
    public void PlayButton()
    {
        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    

}
