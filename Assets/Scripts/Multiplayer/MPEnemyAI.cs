using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPEnemyAI : MonoBehaviour
{
    public Animator animatorP1;
    public Animator animatorP2;
    public Rigidbody2D rigidbody2DP1;
    public Rigidbody2D rigidbody2DP2;

    public MPGameOver mPGameOver;
    MultiPlayer1 multiPlayer1;
    MultiPlayer2 multiPlayer2;
    Enemies enemies;
    bool isColliding;
    bool hitByEnemy;
    void Awake()
    {
        multiPlayer1 = GameObject.Find("Player1").GetComponent<MultiPlayer1>();
        multiPlayer2 = GameObject.Find("Player2").GetComponent<MultiPlayer2>();
        animatorP1 = GameObject.Find("Player1").GetComponent<Animator>();
        animatorP2 = GameObject.Find("Player2").GetComponent<Animator>();
        rigidbody2DP1 = GameObject.Find("Player1").GetComponent<Rigidbody2D>();
        rigidbody2DP2 = GameObject.Find("Player2").GetComponent<Rigidbody2D>();
        mPGameOver = GameObject.Find("GameManager").GetComponent<MPGameOver>();
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

            if (collision.name == "Player1")
            {
                hitByEnemy = true;
                StartCoroutine(multiPlayer1.Die());
               /* Debug.Log(this.tag + " hit " + collision.tag);
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
                    StartCoroutine(multiPlayer1.Die());
                    this.enabled = false;
                }
                else
                {
                    StartCoroutine(playerMovement.OnOneDeath());
                }
                StartCoroutine(Reset());*/

            } 
            if (collision.name == "Player2")
            {
                hitByEnemy = true;
                StartCoroutine(multiPlayer2.Die());
              

            }
        }
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.3f);

        hitByEnemy = false;
    }


}
