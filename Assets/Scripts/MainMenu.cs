using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource onClickBtnSound;
    public AudioSource bgSound;
    public AudioSource level1Music;
    public AudioSource level2Music;
    public GameObject QuitGameMenuUI;
    public static string currentLevel;
    public static string levelReachedName;
    public static string difficultyLevel;
    public static bool isNewGame;
    public Button[] levelBtns;
    public Button newGameBtn;
    public Button levelInOnPlayBtn;
    public GameObject continueBtn;
    GameMaster gm;
    private void Awake()
    {
        isNewGame = true;

    }
    private void Start()
    {

       //PlayerPrefs.SetString("CurrentLevel", "");
        currentLevel = PlayerPrefs.GetString("CurrentLevel", ""); //If non of any levels played yet current level will be null i.e "" due to string
        difficultyLevel = PlayerPrefs.GetString("DifficultyLevel");
        onClickBtnSound = GameObject.FindGameObjectWithTag("SoundEffectGameObject").GetComponent<AudioSource>();
        bgSound = GameObject.FindGameObjectWithTag("BGmusicGameObject").GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        /*
        -----------------Continue button disable if game is install for 1st time -----------------------------------
        */
        if (currentLevel == null || currentLevel == "")
        {
            continueBtn.SetActive(false);
            newGameBtn.transform.position = new Vector3(newGameBtn.transform.position.x + 0, newGameBtn.transform.position.y + 80);
            levelInOnPlayBtn.transform.position = new Vector3(levelInOnPlayBtn.transform.position.x + 0, levelInOnPlayBtn.transform.position.y + 80);
        }
        /*
         -----------------Level Lock Logic Start here -----------------------------------
         */

        levelReachedName = PlayerPrefs.GetString("LevelReached", "Level 1");
        
        PlayerPrefs.SetString("LevelReached", "Level 3"); // to unlock all level , last level must be reached
        int levelReached = 0;
       
        switch (levelReachedName)
        {
            case "Level 1":
                levelReached = 1;
                break;
            case "Level 2":
                levelReached = 2;
                break;
            case "Level 3":
                levelReached = 3;
                break;

            default:

                break;
        }
        //Debug.Log("Level reached" + levelReachedName);
        for (int i = 0; i < levelBtns.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelBtns[i].interactable = false;
            }
        }
        /*
         -----------------Level Lock Logic ends here -----------------------------------
         */
    }
    public void OnPlayBtnclick()
    {
       
    }
    public void PlayGame()
    {
        OnBtnClickSound();

        difficultyLevel = PlayerPrefs.GetString("DifficultyLevel");

        if (currentLevel == null || currentLevel == "")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(currentLevel);
    } 
    public void ContinueGame()
    {
        OnBtnClickSound();
        isNewGame = false;
        difficultyLevel = PlayerPrefs.GetString("DifficultyLevel");
        
        if (currentLevel == null || currentLevel == "")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(currentLevel);
    } 
    
    public void NewGame()
    {
        OnBtnClickSound();
        isNewGame = true;
        difficultyLevel = PlayerPrefs.GetString("DifficultyLevel");
        
        if (currentLevel == null || currentLevel == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetString("CurrentLevel", "Level 1");
        }
           
        else
        {
            SceneManager.LoadScene(currentLevel);
            isNewGame = true;
        }
            
    }

    public void Level1()
    {
        PlayerPrefs.SetString("MultiplayerGame", "False");
        OnBtnClickSound();
        PlayerPrefs.SetString("CurrentLevel", "Level 1");
       // SceneManager.LoadScene("Level 1");
    }
    public void Level2()
    {
        PlayerPrefs.SetString("MultiplayerGame", "False");
        OnBtnClickSound(); 
        PlayerPrefs.SetString("CurrentLevel", "Level 2");
       // SceneManager.LoadScene("Level 2");
    }
    public void Level3()
    {
        PlayerPrefs.SetString("MultiplayerGame", "False");
        OnBtnClickSound();
        PlayerPrefs.SetString("CurrentLevel", "Level 3");
       // SceneManager.LoadScene("Level 3");
    }
    
    public void QuitGameMenu()
    {
        QuitGameMenuUI.SetActive(true);
    }
    public void QuitGame()
    {
        OnBtnClickSound();
        Application.Quit();
        QuitGameMenuUI.SetActive(false);
        Debug.Log("Game Quiting");
    }
    public void NotQuitGame()
    {
        QuitGameMenuUI.SetActive(false);
        Debug.Log("Game Not  Quiting");
    }
    public void OnBtnClickSound()
    {
        onClickBtnSound.Play();
    }
    public void MultiplayerGame()
    {
        PlayerPrefs.SetString("MultiplayerGame", "True");
        bgSound.clip = level2Music.clip;
        bgSound.Play();
        SceneManager.LoadScene("Multiplayer");
    }
    public void CheckLevel()
    {
        isNewGame = true;
        currentLevel = PlayerPrefs.GetString("CurrentLevel", "Level 1");
        switch (currentLevel)
        {
            case "Level 1":
                bgSound.clip = level1Music.clip;
                bgSound.Play();
                SceneManager.LoadScene("Level 1");
                break;
            case "Level 2":

                bgSound.clip = level2Music.clip;
                bgSound.Play();
                SceneManager.LoadScene("Level 2");
                break;
            case "Level 3":
                bgSound.clip = level2Music.clip;
                bgSound.Play();
                SceneManager.LoadScene("Level 3");
                break;

            default:

                break;
            }
    }
    public void Easy()
    {
        difficultyLevel = "easy";
        PlayerPrefs.SetString("DifficultyLevel", "Easy");
        NewGameStrat();
        CheckLevel();
    }
    public void Medium()
    {
        difficultyLevel = "medium";
        NewGameStrat();
        PlayerPrefs.SetString("DifficultyLevel", "Medium");
        CheckLevel();
    }
    public void Hard()
    {
        difficultyLevel = "hard";
        NewGameStrat();
        PlayerPrefs.SetString("DifficultyLevel", "Hard");
        //gm.lastCheckPointPos = null;
        CheckLevel();
    }
     void NewGameStrat()
     {
        Debug.Log(" NewGameStrat()");
        PlayerPrefs.SetInt("CurrentHealth", 100);
        PlayerPrefs.SetInt("Lifes", 3);
        PlayerPrefs.SetInt("ArrowPlayerHas", 10);
        PlayerPrefs.SetInt("RecentGemCollected", 0);
        PlayerPrefs.SetInt("RecentCherryCollected", 0);
        PlayerPrefs.SetInt("GemCollectedTillLastCheckPoint", 0);
        PlayerPrefs.SetInt("CherryCollectedTillLastCheckPoint",0);
    }
}
