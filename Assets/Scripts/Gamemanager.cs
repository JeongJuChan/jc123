using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager m_instance;
    bool stopping;
    
    // 시간정지 정수부
    public float stopTime;
    public float slowTime;

    public Animator playerAnim;

    public CinemachineFramingTransposer cam;

    public int combo;
    public int maxCombo;

    public int coin;
    public int activeSceneIndex;

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

    private void Awake() 
    {   
        cam = FindObjectOfType<CinemachineFramingTransposer>();
        GameLoad();
    }
    
    private void Start() 
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
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

        UImanager.instance.nextButton.SetActive(true);
        UImanager.instance.restartButton.SetActive(true);
    }

    public void Combo() 
    {
        if (!playerAnim.GetBool("isJump"))
        {
            combo++;
            if (combo > maxCombo) maxCombo = combo;

            UImanager.instance.ComboUI(combo);
            

            GetCoin();
        }
    }
    
    void GetCoin()
    {
        coin += combo;
        UImanager.instance.CoinUI(coin);
    }

    public void GetCoin(int stack)
    {
        coin += maxCombo * stack;
        UImanager.instance.CoinUI(coin);
    }

    public void SceneLoadManager(int plus)
    {
        SceneManager.LoadScene(activeSceneIndex + plus);
    }

    public void GameSave()
    {
        PlayerPrefs.SetInt("Coin", coin);
        Debug.Log(coin);
        PlayerPrefs.Save();
    }

    public void GameLoad()
    {
        int money = PlayerPrefs.GetInt("Coin");
        coin = money;
        UImanager.instance.CoinUI(coin);
    }

}
