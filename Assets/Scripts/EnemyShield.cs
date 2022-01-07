using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public Animator animator;
    private Transform player;
    private float distance;
    public  bool activeShield;
    MelleAttack melleAttack;
    void Start()
    {
        //melleAttack =  GetComponent<MelleAttack>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        activeShield = false;
        animator.SetBool("Sheild", false);
        distance = 7;
    }

    // Update is called once per frame
    void Update()
    {
        player.position = player.transform.position;
        if (Vector2.Distance(transform.position, player.position) < distance && animator.GetBool("Attack") == false) 
        {
            //Debug.Log("sheild Active !! "  );
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
                //melleAttack.inRange = true;
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

