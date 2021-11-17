using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource onClickBtnSound;
    public GameObject QuitGameMenuUI;
    public static string currentLevel;
    public static string levelReachedName;
    public Button[] levelBtns;
    private void Start()
    {
        currentLevel = PlayerPrefs.GetString("CurrentLevel", "Level 1");
        onClickBtnSound = GameObject.FindGameObjectWithTag("SoundEffectGameObject").GetComponent<AudioSource>();
        /*
         -----------------Level Lock Logic Start here -----------------------------------
         */

        levelReachedName = PlayerPrefs.GetString("LevelReached", "Level 1");
        
        //PlayerPrefs.SetString("LevelReached", "Level 3"); // to unlock all level , last level must be reached
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
        Debug.Log("Level reached" + levelReachedName);
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
    public void PlayGame()
    {
        OnBtnClickSound();
        if(currentLevel == null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(currentLevel);
    }
    public void Level1()
    {
        OnBtnClickSound();
        PlayerPrefs.SetString("CurrentLevel", "Level 1");
        SceneManager.LoadScene("Level 1");
    }
    public void Level2()
    {
        OnBtnClickSound(); 
        PlayerPrefs.SetString("CurrentLevel", "Level 2");
        SceneManager.LoadScene("Level 2");
    }
    public void Level3()
    {
        OnBtnClickSound();
        PlayerPrefs.SetString("CurrentLevel", "Level 3");
        SceneManager.LoadScene("Level 3");
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
}
