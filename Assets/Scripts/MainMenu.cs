using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource onClickBtnSound;
    public void PlayGame()
    {
        OnBtnClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        SceneManager.LoadScene("Level 3");
    }
    public void QuitGame()
    {
        OnBtnClickSound();
        Debug.Log("Application Quit");
        Application.Quit();
    }
    public void OnBtnClickSound()
    {
        onClickBtnSound.Play();
    }
}
