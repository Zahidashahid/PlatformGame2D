using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemyMovement : MonoBehaviour
{

   /* private BoxCollider2D boxCollider2d;*/

    public Rigidbody2D rb;
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;
    int direction = 1;


    private void Awake()
    {
       // boxCollider2d = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {   if(direction == 1)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            transform.localScale = new Vector2(5, 5);
        }
        else
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            transform.localScale = new Vector2(-5, 5);
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with " + collision.tag);
        if (collision.tag == "Obstacles")
        {
            if (direction == 1)
            {
                direction = 2;
            }
            else
                direction = 1;

        }
       

    }
   
    public void TakeDemage(int demage)
    {
        currentHealth -= demage;
        
        // play hurt animation
        StartCoroutine(HurtAnimation());
        if (currentHealth <= 0)
        {
            StartCoroutine( Die());
        }
    }
     IEnumerator HurtAnimation()
     {
        // play hurt animation
        animator.SetBool("Sheild", true);
        yield return new WaitForSeconds(0.6f);
         animator.SetBool("Sheild", false);

     }
    IEnumerator Die()
    {
        // Die Animation

        animator.SetBool("Death", true);
        Debug.Log("Skeleton died!");
        yield return new WaitForSeconds(2f);
        // Disable the player
         Destroy(gameObject);
    }
}
