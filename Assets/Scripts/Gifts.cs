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
    CircleCollider2D collider;
    //public AudioSource giftSound;
    private void Start()
    {
        gemCount = PlayerPrefs.GetInt("CherryCollected");
        cherryCount = PlayerPrefs.GetInt("GemCollected");
        PlayerPrefs.SetInt("RecentGemCollected", PlayerPrefs.GetInt("GemCollectedTillLastCheckPoint"));
        PlayerPrefs.SetInt("RecentCherryCollected", PlayerPrefs.GetInt("CherryCollectedTillLastCheckPoint"));
        collider = GetComponent<CircleCollider2D>();
        cherryAmount =  PlayerPrefs.GetInt("RecentCherryCollected");
        gemAmount = PlayerPrefs.GetInt("RecentGemCollected");
        Debug.Log("gemAmount =" + PlayerPrefs.GetInt("RecentGemCollected"));
        Debug.Log("cherryAmount =" + PlayerPrefs.GetInt("RecentCherryCollected"));
        Debug.Log("gift data fatched");

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if ( collision.tag == "Cherry")
        {
            
            cherryCount += 1;
            cherryAmount += 1;
            Debug.Log("Amount Cherry " + cherryAmount);
            PlayerPrefs.SetInt("CherryCollected", cherryCount);
            PlayerPrefs.SetInt("RecentCherryCollected", cherryAmount);
            scoreManager.CherryCollect();
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.giftSound);
            Destroy(collision.gameObject);
        }
        if ( collision.tag == "Gem")
        {
            gemAmount += 1;
            gemCount += 1;
            Debug.Log("gem Amount " + gemAmount);
            PlayerPrefs.SetInt("GemCollected", gemCount);
            PlayerPrefs.SetInt("RecentGemCollected", gemAmount);
            scoreManager.GemCollect();
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.giftSound);
            Destroy(collision.gameObject);
        }
        collider.enabled= false;
    }
   
}
