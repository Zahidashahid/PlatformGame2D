using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArrowHit : MonoBehaviour
{/*
    #region public variables 
    public Animator playerAnimator;
    public Transform attackPoint;
    public Rigidbody2D rigidbody2D;
    public LayerMask playerLayers;
    public float attackRange = 0.05f;
    #endregion
    #region private variables 
    #endregion

    void Attack()
    {
        //play an attack animation
        //deteck enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        // demage them
        foreach (Collider2D enemy in hitEnemies)
        {
            // Destroy();
            Debug.Log("We hit player");
            enemy.GetComponent<PlayerMovement>().TakeDemage(50);
           
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collision.tag == "Player")
        {
            Debug.Log("enemy hit " + collision.tag);
            // collisionGameObject.GetComponent<PlayerMovement>().TakeDemage(30);
            //playerAnimator.SetBool("Ishurt", true);
            *//*     playerMovement.enabled = false;
                 enemies.enabled = false;*//*
            // rigidbody2D.bodyType = RigidbodyType2D.Static;
            Attack();
            ///FindObjectOfType<GameUIScript>().GameOver();
            //gameUIScript.GameOver();
            //  Destroy(collision.gameObject, 1f);
        }


    }*/
}
