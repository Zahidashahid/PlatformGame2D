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
    }
    void Start()
    {
        hitByEnemy = false;
    }
  
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.tag + " hit " + collision.name);
        if (!hitByEnemy)
        {
            GameObject collisionGameObject = collision.gameObject;

            if (collision.name == "Player1")
            {
                hitByEnemy = true;
                StartCoroutine(multiPlayer1.Die());
                StartCoroutine(Reset());
            } 
            if (collision.name == "Player2")
            {
                hitByEnemy = true;
                StartCoroutine(multiPlayer2.Die());
                StartCoroutine(Reset());
            }
        }
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);

        hitByEnemy = false;
    }


}
