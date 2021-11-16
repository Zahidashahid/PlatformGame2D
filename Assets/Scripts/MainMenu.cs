using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource onClickBtnSound;
    public GameObject QuitGameMenuUI;
    public static string currentLevel;
    private void Start()
    {
        currentLevel = PlayerPrefs.GetString("CurrentLevel");
        onClickBtnSound = GameObject.FindGameObjectWithTag("SoundEffectGameObject").GetComponent<AudioSource>();
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
        SceneManager.LoadScene("Level 1");
    }
    public void Level2()
    {
        OnBtnClickSound();
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
