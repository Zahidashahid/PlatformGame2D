using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameUIScript : MonoBehaviour
{
    public Button button;
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;
    public GameObject restartButton;
    

    void Awake()
    {
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
       gameOverText.enabled = false;
    }

    public void StartGame()
    {
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        gameOverText.enabled = false;
    }



    public void GameOver()
    {
        Debug.Log("Game is Over.");
        gameOverPanel.SetActive(true);
        restartButton.SetActive(true);
        gameOverText.enabled = true;
    }

    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        gameOverText.enabled = false;
        SceneManager.LoadScene("Level1");
    }

   

}

