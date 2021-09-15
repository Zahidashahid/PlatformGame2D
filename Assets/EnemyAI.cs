  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameUIScript gameUIScript;
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        Debug.Log("Player hit " + collision.tag);
        if (collision.tag == "Player")
        {
            
            Destroy(collision.gameObject);
            FindObjectOfType<GameUIScript>().GameOver();
            //gameUIScript.GameOver();
        }
    }
}
