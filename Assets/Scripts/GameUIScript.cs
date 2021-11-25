using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameUIScript : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameOverCanvas;
    public TMP_Text gameOverText;
    public GameObject restartButton;
    public GameObject SkeletonSpwan;
   // public GameObject EnemyEagleSpwan;
    public GameObject RangeAttackSpwan;
    public GameObject RangeAttackPointSpwan;
    public AudioSource restartBtnSound;
    public AudioSource bgSound;
    MainMenu mainMenu;
    PlayerMovement playerMovement;
    void Awake()
    {
        /* gameOverPanel.SetActive(false);
         restartButton.SetActive(false);
        gameOverText.enabled = false;*/
    }

    public void Start()
    {
        /*gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        gameOverText.enabled = false;*/

        bgSound = GameObject.FindGameObjectWithTag("BGmusicGameObject").GetComponent<AudioSource>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        mainMenu = GameObject.FindGameObjectWithTag("GM").GetComponent<MainMenu>();
        
        
        string difficultyLevel = PlayerPrefs.GetString("DifficultyLevel");
        //Debug.Log("Difficulity" + MainMenu.difficultyLevel);
        if (difficultyLevel == "Medium")
        {
            SkeletonSpwan.SetActive(true);
           // EnemyEagleSpwan.SetActive(true);
        }
        if(difficultyLevel == "Hard")
        {
            SkeletonSpwan.SetActive(true);
            //EnemyEagleSpwan.SetActive(true);
            RangeAttackPointSpwan.SetActive(true);
            RangeAttackSpwan.SetActive(true);
        }
    }
    public void GameOver()
    {
        StartCoroutine(waiter());
        //SceneManager.LoadScene("Level 1");
        //SceneManager.LoadScene("GameOver");
    }
    public void RestartGameFromLastCheckPoint() 
    {
        /*        gameOverPanel.SetActive(false);
                restartButton.SetActive(false);
                gameOverText.enabled = false;*/
        //SceneManager.LoadScene("Level 1");
        restartBtnSound.Play();/*
        PlayerPrefs.SetInt("RecentGemCollected", 0);
        PlayerPrefs.SetInt("RecentCherryCollected", 0);
        PlayerPrefs.SetInt("ArrowPlayerHas", 10);*/
        //Reset the last check point
        bgSound.Play();
        Time.timeScale = 1f;

        PlayerPrefs.SetInt("RecentGemCollected", PlayerPrefs.GetInt("GemCollectedTillLastCheckPoint"));
        PlayerPrefs.SetInt("RecentCherryCollected", PlayerPrefs.GetInt("CherryCollectedTillLastCheckPoint"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }public void RestartGame() //When Game is over after complete death i.e zero lifes left
    {
        /*        gameOverPanel.SetActive(false);
                restartButton.SetActive(false);
                gameOverText.enabled = false;*/
        //SceneManager.LoadScene("Level 1");
        restartBtnSound.Play();
        PlayerPrefs.SetInt("ArrowPlayerHas", 10);

        PlayerPrefs.SetInt("RecentGemCollected", 0);
        PlayerPrefs.SetInt("RecentCherryCollected", 0);
        PlayerPrefs.SetInt("GemCollectedTillLastCheckPoint", 0);
        PlayerPrefs.SetInt("CherryCollectedTillLastCheckPoint", 0);
        //Reset the last check point
        bgSound.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartLevel()
    {
        playerMovement.Reset();
        //Reset Gift collected
        PlayerPrefs.SetInt("RecentGemCollected", 0);
        PlayerPrefs.SetInt("RecentCherryCollected", 0);
        PlayerPrefs.SetInt("GemCollectedTillLastCheckPoint", 0);
        PlayerPrefs.SetInt("CherryCollectedTillLastCheckPoint", 0);
        //Reset arrow Store
        PlayerPrefs.SetInt("ArrowPlayerHas", 10);
        //Reset Last check point
        string currentLevel = PlayerPrefs.GetString("CurrentLevel");
        SceneManager.LoadScene(currentLevel);
        Debug.Log(" RestartLevel() Called");
    }
    public void  Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
    IEnumerator waiter()
    {
        //Wait for 1 seconds
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Game is Over.");
        gameOverCanvas.SetActive(true);
        gameOverPanel.SetActive(true);
        restartButton.SetActive(true);
        gameOverText.enabled = true;
        Time.timeScale = 0f;
    }
 
}

