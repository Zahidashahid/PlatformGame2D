using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gifts : MonoBehaviour
{
    public static int gemAmount;//Total amount of gems collected after end of level 
    public static int gemCount;//Amount of gems in prefrences
    public static int cherryAmount;//Total amount of cherry collected after end of level 
    public static int cherryCount;//Amount of cherry in prefrences
    public ScoreManager scoreManager;
   // Collider collider;
    //public AudioSource giftSound;
    private void Start()
    {
        gemCount = PlayerPrefs.GetInt("CherryCollected");
        cherryCount = PlayerPrefs.GetInt("GemCollected");
        PlayerPrefs.SetInt("RecentGemCollected", PlayerPrefs.GetInt("GemCollectedTillLastCheckPoint"));
        PlayerPrefs.SetInt("RecentCherryCollected", PlayerPrefs.GetInt("CherryCollectedTillLastCheckPoint"));
        //collider = GetComponent<Collider>();
        cherryAmount =  PlayerPrefs.GetInt("RecentCherryCollected");
        gemAmount = PlayerPrefs.GetInt("RecentGemCollected");
        Debug.Log("gemAmount =" + PlayerPrefs.GetInt("RecentGemCollected"));
        Debug.Log("cherryAmount =" + PlayerPrefs.GetInt("RecentCherryCollected"));
        Debug.Log("gift data fatched");

    }
    private void Update()
    {
        string currentLevel = PlayerPrefs.GetString("CurrentLevel");
        if (currentLevel == "Level 1" || currentLevel == "Level 2")
        {
            PlayerPrefs.SetInt("GemCollectedTillLastCheckPoint", PlayerPrefs.GetInt("RecentGemCollected"));
            PlayerPrefs.SetInt("CherryCollectedTillLastCheckPoint", PlayerPrefs.GetInt("RecentCherryCollected"));
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        
        if ( tag == "Cherry")
        {
            collision.enabled = false;
            Destroy(collision.gameObject);
            cherryCount += 1;
            cherryAmount += 1;
            Debug.Log("Amount Cherry " + cherryAmount);
            PlayerPrefs.SetInt("CherryCollected", cherryCount);
            PlayerPrefs.SetInt("RecentCherryCollected", cherryAmount);
            scoreManager.CherryCollect();
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.giftSound);
            
        }
        if ( tag == "Gem")
        {
            collision.enabled = false;
            Destroy(collision.gameObject);
            gemAmount += 1;
            gemCount += 1;
            Debug.Log("gem Amount " + gemAmount);
            PlayerPrefs.SetInt("GemCollected", gemCount);
            PlayerPrefs.SetInt("RecentGemCollected", gemAmount);
            scoreManager.GemCollect();
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.giftSound);
            
        }
        
    }
   
}
