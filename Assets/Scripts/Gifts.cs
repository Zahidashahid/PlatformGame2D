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
    //public AudioSource giftSound;
    private void Start()
    {
        gemCount = PlayerPrefs.GetInt("CherryCollected");
        cherryCount = PlayerPrefs.GetInt("GemCollected");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if ( collision.tag == "Cherry")
        {
            //ScoreManager scriptToAccess = ScoreManager.GetComponent<ScoreManager>();
            /*gemAmount = gemAmount + 1;
            gemCount += gemAmount;*/
            gemCount += 1;
            PlayerPrefs.SetInt("CherryCollected", gemCount);
            scoreManager.CherryCollect();
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.giftSound);
            Destroy(collision.gameObject);
        }
        if ( collision.tag == "Gem")
        {
            /*cherryAmount = cherryAmount + 1;
            cherryCount += cherryAmount;*/
            cherryCount += 1;
            PlayerPrefs.SetInt("GemCollected", cherryCount);
            scoreManager.GemCollect();
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.giftSound);
            Destroy(collision.gameObject);
        }
    }
}
