using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameUIScript : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameOverCanvas;
    public TMP_Text gameOverText;
    public GameObject restartButton;
    public AudioSource restartBtnSound;
    void Awake()
    {
       /* gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
       gameOverText.enabled = false;*/
    }

    public void StartGame()
    {
        /*gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        gameOverText.enabled = false;*/
    }



    public void GameOver()
    {
        StartCoroutine(waiter());
        //SceneManager.LoadScene("Level 1");
        //SceneManager.LoadScene("GameOver");
    }

    public void RestartGame()
    {
        /*        gameOverPanel.SetActive(false);
                restartButton.SetActive(false);
                gameOverText.enabled = false;*/
        //SceneManager.LoadScene("Level 1");
        restartBtnSound.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator waiter()
    {
        //Wait for 1 seconds
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Game is Over.");
        gameOverCanvas.SetActive(true);
        gameOverPanel.SetActive(true);
        restartButton.SetActive(true);
        gameOverText.enabled = true;
        Time.timeScale = 0f;
    }

}

