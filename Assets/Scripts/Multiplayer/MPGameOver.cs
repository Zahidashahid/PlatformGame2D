using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MPGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameOverCanvas;
    public TMP_Text gameOverText;
    public GameObject restartButton;
    //public GameObject SkeletonSpwan;
    public GameObject pauseMenuPanel;
    public GameObject BGPanel;
    public GameObject EnemyCanvas;
   /* public GameObject RangeAttackSpwan;
    public GameObject RangeAttackPointSpwan;*/
    public AudioSource restartBtnSound;
    public AudioSource bgSound;
    MainMenu mainMenu;
    GameMaster gm;
    public ScoreManager scoreManager;
    string difficultyLevel;

    public static bool isNewGame;

    public void Start()
    {
        /*gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        gameOverText.enabled = false;*/
        isNewGame = false;

        bgSound = GameObject.FindGameObjectWithTag("BGmusicGameObject").GetComponent<AudioSource>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        mainMenu = GameObject.FindGameObjectWithTag("GM").GetComponent<MainMenu>();

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();


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
        restartBtnSound.Play();
        isNewGame = false;
        PauseGame.isGamePaused = false;
        /*
        PlayerPrefs.SetInt("RecentGemCollected", 0);
        PlayerPrefs.SetInt("RecentCherryCollected", 0);
        PlayerPrefs.SetInt("ArrowPlayerHas", 10);*/
        //Reset the last check point
        bgSound.Play();
        Time.timeScale = 1f;
        float x = PlayerPrefs.GetFloat("LastcheckPointX");
        float y = PlayerPrefs.GetFloat("LastcheckPointy");
        gm.lastCheckPointPos = new Vector2(x, y);
        //playerMovement.transform.position = gm.lastCheckPointPos;
        Debug.Log(difficultyLevel);
        if (difficultyLevel == "Easy")
        {
            return;
            /*PlayerPrefs.SetInt("RecentGemCollected", PlayerPrefs.GetInt("RecentGemCollected"));
            PlayerPrefs.SetInt("RecentCherryCollected", PlayerPrefs.GetInt("RecentCherryCollected"));*/
        }
        else if (difficultyLevel == "Medium")
        {
            PlayerPrefs.SetInt("RecentGemCollected", PlayerPrefs.GetInt("GemCollectedTillLastCheckPoint"));
            PlayerPrefs.SetInt("RecentCherryCollected", PlayerPrefs.GetInt("CherryCollectedTillLastCheckPoint"));
        }
        else if (difficultyLevel == "Hard")
        {
            PlayerPrefs.SetInt("RecentGemCollected", PlayerPrefs.GetInt("GemCollectedTillLastCheckPoint"));
            PlayerPrefs.SetInt("RecentCherryCollected", PlayerPrefs.GetInt("CherryCollectedTillLastCheckPoint"));
        }
        // playerMovement.transform.position = gm.lastCheckPointPos;


        scoreManager.UpdateCherryText(PlayerPrefs.GetInt("RecentCherryCollected"));
        scoreManager.UpdateGemText(PlayerPrefs.GetInt("RecentGemCollected"));



       // playerMovement.transform.position = new Vector2(x, y);
        pauseMenuPanel.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RestartGame() //When Game is over after complete death i.e zero lifes left
    {
        /*        gameOverPanel.SetActive(false);
                restartButton.SetActive(false);
                gameOverText.enabled = false;*/
        //SceneManager.LoadScene("Level 1");
        restartBtnSound.Play();
        isNewGame = true;
        PlayerPrefs.SetInt("ArrowPlayerHas", 10);

        PlayerPrefs.SetInt("RecentGemCollected", 0);
        PlayerPrefs.SetInt("RecentCherryCollected", 0);
        PlayerPrefs.SetInt("GemCollectedTillLastCheckPoint", 0);
        PlayerPrefs.SetInt("CherryCollectedTillLastCheckPoint", 0);
        //Reset the last check point
        bgSound.Play();
        Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gm.lastCheckPointPos = new Vector2(0, 0);
        string currentLevel = PlayerPrefs.GetString("CurrentLevel");
        SceneManager.LoadScene(currentLevel);
    }

    public void RestartLevel()
    {
      //  playerMovement.Reset();
        isNewGame = true;

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
    public void MainMenu()
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
        BGPanel.SetActive(false);
        EnemyCanvas.SetActive(false);
        gameOverText.enabled = true;
        Time.timeScale = 0f;

    }

}

