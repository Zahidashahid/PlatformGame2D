using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        isGamePaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }   
    void Pause()
    {
        isGamePaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quiting");
    }

}

