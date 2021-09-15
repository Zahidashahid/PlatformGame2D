  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public GameUIScript gameUIScript;
    PlayerMovement playerMovement;
    Enemies enemies;
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        enemies = GetComponentInChildren<Enemies>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        Debug.Log("Player hit " + collision.tag);
        if (collision.tag == "Player")
        {
            animator.SetBool("Ishurt", true);
       /*     playerMovement.enabled = false;
            enemies.enabled = false;*/
            //Destroy(collision.gameObject);
            FindObjectOfType<GameUIScript>().GameOver();
            gameUIScript.GameOver();
        }
    }
}
