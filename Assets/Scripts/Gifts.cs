using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gifts : MonoBehaviour
{
    public ScoreManager scoreManager = new ScoreManager();
    public AudioSource giftSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if ( collision.tag == "Cherry")
        {
            //ScoreManager scriptToAccess = ScoreManager.GetComponent<ScoreManager>();
            scoreManager.CherryCollect();
            giftSound.Play();
            Destroy(collision.gameObject);
        }
        if ( collision.tag == "Gem")
        {
            scoreManager.GemCollect();
            giftSound.Play();
            Destroy(collision.gameObject);
        }
    }
}
