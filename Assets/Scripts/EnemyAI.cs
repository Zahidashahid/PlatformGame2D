  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public GameUIScript gameUIScript;
    PlayerMovement playerMovement;
    Enemies enemies;
    public Rigidbody2D rigidbody2D;
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        enemies = GetComponentInChildren<Enemies>();
    }
    void Start()
    {
       // animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        Debug.Log("Enemy hit " + collision.tag);
        if (collision.tag == "Player")
        {
            animator.SetBool("Ishurt", true);
            /*     playerMovement.enabled = false;
                 enemies.enabled = false;*/
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            FindObjectOfType<GameUIScript>().GameOver();
            //gameUIScript.GameOver();
          //  Destroy(collision.gameObject, 1f);
        }
    }
   
}
