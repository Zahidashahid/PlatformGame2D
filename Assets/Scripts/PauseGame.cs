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
    bool hitBtnPressed;
    private void Awake()
    {
        controls = new PlayerController();
        controls.Gameplay.PauseGame.performed += ctx => OnApplicationPause();

    }
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
       // hitBtnPressed = Input.GetKeyDown(KeyCode.O);
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
    void OnApplicationFocus(bool hasFocus)
    {
        isGamePaused = !hasFocus;
        if (hasFocus == false)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    void OnApplicationPause()
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
    void PauseGamePress()
    {
        
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
        isGamePaused = false;
        GameUIScript.isNewGame = true;
        SceneManager.LoadScene("Main Menu");
    }
    public void NotLoadMenuGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
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
        isGamePaused = false;
        Application.Quit();
        QuitGameMenuUI.SetActive(false);
        Debug.Log("Game Quiting");
     }
    public void NotQuitGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
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

