using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gifts : MonoBehaviour
{
    public ScoreManager scoreManager = new ScoreManager();

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        
        if ( collision.tag == "Cherry")
        {

            //ScoreManager scriptToAccess = ScoreManager.GetComponent<ScoreManager>();

            scoreManager.CherryCollect();
            Destroy(collision.gameObject);
        }
        if ( collision.tag == "Gem")
        {
            scoreManager.GemCollect();
            Destroy(collision.gameObject);
        }

    }
     
}
