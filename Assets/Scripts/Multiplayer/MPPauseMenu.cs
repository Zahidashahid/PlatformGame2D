using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MPPauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameModeUI;
    public GameObject QuitGameMenuUI;
    public GameObject EnemyCanvasUI;
    PlayerController controls;
    private void Awake()
    {
        controls = new PlayerController();
        controls.Gameplay.PauseGame.performed += ctx => PauseGamePress();
    }
    void Update()
    {
        /*  if(Input.GetKeyDown(KeyCode.Escape))
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
          }*/
    }
    void PauseGamePress()
    {
        if (!isGamePaused)
        {

            Pause();
            Debug.Log("Pause called");
        }
        else if (isGamePaused)
        {
            Resume();
            Debug.Log("Resume called");
        }
    }
    public void Resume()
    {
        isGamePaused = false;
        pauseMenuUI.SetActive(false);
        gameModeUI.SetActive(true);
        EnemyCanvasUI.SetActive(true);
        Time.timeScale = 1f;
    }
    void Pause()
    {
        isGamePaused = true;
        gameModeUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        EnemyCanvasUI.SetActive(false);
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");

    }
    public void RestartLevel()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Multiplayer");
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
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}

