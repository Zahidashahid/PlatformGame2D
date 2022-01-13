using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoder : MonoBehaviour
{

    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntegerToLoadLevel = false ;
    public AudioSource audioSrc; //bg Muisic
  
    private void Start()
    {
        audioSrc = GameObject.FindGameObjectWithTag("BGmusicGameObject").GetComponent<AudioSource>();
      
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("collision " , collision);
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag == "Player")
        {
            LoadLevel();
        } 
       
    }
    public void LoadLevel()
    {
        PlayerPrefs.SetInt("LevelCompleted", 1);
        if (useIntegerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
            PlayerPrefs.SetString("CurrentLevel", sLevelToLoad);
            audioSrc.mute = true;
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.missionCompletetSound);
            PlayerPrefs.SetString("LevelReached", sLevelToLoad);

        }
    }
}
