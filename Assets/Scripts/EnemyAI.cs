  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody2D;

    public GameUIScript gameUIScript;
    PlayerMovement playerMovement;
    Enemies enemies;
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
       
        if (collision.tag == "Player")
        {
            Debug.Log(this.tag + " hit " + collision.tag);
            // collisionGameObject.GetComponent<PlayerMovement>().TakeDemage(30);
            //animator.SetBool("Ishurt", true);
            /*     playerMovement.enabled = false;
                 enemies.enabled = false;*/
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            FindObjectOfType<GameUIScript>().GameOver();

            
            //gameUIScript.GameOver();
          //  Destroy(collision.gameObject, 1f);
        }

       
    }
   
}
