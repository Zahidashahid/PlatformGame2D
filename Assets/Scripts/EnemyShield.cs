using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public Animator animator;
    private Transform player1;
    private Transform player2;
    private float distance;
    public  bool activeShield;
    void Start()
    {
        animator = GetComponent<Animator>();
        player1 = GameObject.Find("Player1").transform;
        player2 = GameObject.Find("Player2").transform;
        activeShield = false;
        animator.SetBool("Sheild", false);
        distance = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2.Distance(transform.position, player1.position) < distance && animator.GetBool("Attack") == false) 
            || (Vector2.Distance(transform.position, player2.position) < distance && animator.GetBool("Attack") == false))
        {
            animator.SetBool("Sheild", true);
            activeShield = true;
         
        }
        else
        {
            animator.SetBool("Sheild", false);
            activeShield = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Collision "+collision);
            if (!activeShield)
            {
                animator.SetBool("Sheild", true);
                activeShield = true;
            }
           
        }
    }
   
    public bool ActiveShield
    {
        get
        {
            return activeShield;
        }
        set
        {
            activeShield = value;
        }
    }
}

