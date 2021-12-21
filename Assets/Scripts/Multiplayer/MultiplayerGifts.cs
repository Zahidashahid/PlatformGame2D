using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerGifts : MonoBehaviour
{
    public static int player1gemAmount;//Total amount of gems collected after end of level 
    public static int player2gemAmount;//Total amount of gems collected after end of level 
/*    public static int gemCount;//Amount of gems in prefrences*/
    public static int player1cherryAmount;//Total amount of cherry collected after end of level 
    public static int player2cherryAmount;//Total amount of cherry collected after end of level 
/*    public static int cherryCount;//Amount of cherry in prefrences*/
    public MPScoreManager scoreManager;

    private void Start()
    {
        /*gemCount = PlayerPrefs.GetInt("CherryCollected");
        cherryCount = PlayerPrefs.GetInt("GemCollected");
        PlayerPrefs.SetInt("RecentGemCollected", PlayerPrefs.GetInt("GemCollectedTillLastCheckPoint"));
        PlayerPrefs.SetInt("RecentCherryCollected", PlayerPrefs.GetInt("CherryCollectedTillLastCheckPoint"));*/
        //collider = GetComponent<Collider>();
      /*  cherryAmount = PlayerPrefs.GetInt("RecentCherryCollected");
        gemAmount = PlayerPrefs.GetInt("RecentGemCollected");
        Debug.Log("gemAmount =" + PlayerPrefs.GetInt("RecentGemCollected"));
        Debug.Log("cherryAmount =" + PlayerPrefs.GetInt("RecentCherryCollected"));
        Debug.Log("gift data fatched");*/

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;

        if (tag == "Cherry")
        {
            collision.enabled = false;
            Destroy(collision.gameObject);
            /*cherryCount += 1;*/
           
            if(this.name == "Player1")
            {
                player1cherryAmount += 1;
                scoreManager.CherryCollect(this.name, player1cherryAmount);
                Debug.Log("p1 Amount Cherry " + player1cherryAmount);
            }
            else if (this.name == "Player2")
            {
                player2cherryAmount += 1;
                scoreManager.CherryCollect(this.name, player2cherryAmount);
                Debug.Log("p2 Amount Cherry " + player2cherryAmount);
            }
            /*PlayerPrefs.SetInt("CherryCollected", cherryCount);
            PlayerPrefs.SetInt("RecentCherryCollected", cherryAmount);*/
           
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.giftSound);

        }
        if (tag == "Gem")
        {
            collision.enabled = false;
            Destroy(collision.gameObject);
            if (this.name == "Player1")
            {
                player1gemAmount += 1;
                Debug.Log("Amount player1gemAmount " + player1gemAmount);
                scoreManager.GemCollect(this.name, player1gemAmount);
            }
            else if (this.name == "Player2")
            {
                player2gemAmount += 1;
                Debug.Log("Amount player2gemAmount " + player2gemAmount);
                scoreManager.GemCollect(this.name, player2gemAmount);
            }
            /*  gemCount += 1;*/
          /*  PlayerPrefs.SetInt("GemCollected", gemCount);
            PlayerPrefs.SetInt("RecentGemCollected", gemAmount);*/
            
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.giftSound);

        }

    }

}



