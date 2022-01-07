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
    public GameObject MainMenuConformationPopUpUI;
    PlayerController controls;
    PlayerMovement playerMovement;
    private void Awake()
    {
        controls = new PlayerController();
        controls.Gameplay.PauseGame.performed += ctx => PauseGamePress();

    }
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
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
        MainMenuConformationPopUpUI.SetActive(false);
        QuitGameMenuUI.SetActive(false);
        gameModeUI.SetActive(true);
        Time.timeScale = 1f;
    }   
    void Pause()
    {
        isGamePaused = true;
       // gameModeUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MainMenuConformationPopUp()
    {
        MainMenuConformationPopUpUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        playerMovement.Reset();
        GameUIScript.isNewGame = true;
        SceneManager.LoadScene("Main Menu");
    }
    public void NotLoadMenuGame()
    {
        Time.timeScale = 1f;
        MainMenuConformationPopUpUI.SetActive(false);
        Debug.Log("Game Not  Quiting");
    }
    public void QuitGameMenu()
    {
        QuitGameMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
     public void QuitGame()
     {
        Time.timeScale = 1f;
        Application.Quit();
        QuitGameMenuUI.SetActive(false);
        Debug.Log("Game Quiting");
     }
    public void NotQuitGame()
    {
        Time.timeScale = 1f;
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

