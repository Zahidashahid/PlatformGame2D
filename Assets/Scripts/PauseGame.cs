using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameModeUI;
    public GameObject QuitGameMenuUI;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isGamePaused)
            {

                Pause();
                Debug.Log("Pause called"); 
            }
            else if(isGamePaused)
            {
                Resume();
                Debug.Log("Resume called");
            }
        }
    }
    public void Resume()
    {
        isGamePaused = false;
        pauseMenuUI.SetActive(false);
       // gameModeUI.SetActive(true);
        Time.timeScale = 1f;
    }   
    void Pause()
    {
        isGamePaused = true;
       // gameModeUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGameMenu()
    {
        QuitGameMenuUI.SetActive(true);
    }
     public void QuitGame()
     {
        Application.Quit();
        QuitGameMenuUI.SetActive(false);
        Debug.Log("Game Quiting");
     }
    public void NotQuitGame()
    {
        QuitGameMenuUI.SetActive(false);
        Debug.Log("Game Not  Quiting");
    }

}

