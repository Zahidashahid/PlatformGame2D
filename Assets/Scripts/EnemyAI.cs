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
    bool isColliding;
    bool hitByEnemy;
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        rigidbody2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        gameUIScript = GameObject.Find("GameManager").GetComponent<GameUIScript>();
        enemies = GetComponentInChildren<Enemies>();
    }
    void Start()
    {
        // animator = GetComponent<Animator>();
        //Debug.Log(playerMovement.lifes + "lifes left");
        hitByEnemy = false;
    }
    private void FixedUpdate()
    {
       // isColliding = false;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.tag + " hit " + collision.tag);
        if (!hitByEnemy)
        {
            GameObject collisionGameObject = collision.gameObject;

            if (collision.tag == "Player")
            {
                hitByEnemy = true;
                Debug.Log(this.tag + " hit " + collision.tag);
                playerMovement.lifes -= 1;
                Debug.Log("lifes left " + playerMovement.lifes);
                playerMovement.lifesText.text = "X " + playerMovement.lifes;
                PlayerPrefs.SetInt("Lifes", playerMovement.lifes);

                if (playerMovement.lifes <= 0)
                {
                    // bgSound.Stop();
                    PlayerPrefs.SetInt("CurrentHealth", 100);
                    PlayerPrefs.SetInt("Lifes", 3);
                    SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.deathSound);
                    StartCoroutine(playerMovement.Die());
                    this.enabled = false;
                }
                else
                {
                    StartCoroutine(playerMovement.OnOneDeath());
                }
                StartCoroutine(Reset());
                
            }
        }
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.3f);
        
       if(this.CompareTag("Enemy"))
       {
           Destroy(gameObject);
       }
        hitByEnemy = false;
    }
    
   
}
