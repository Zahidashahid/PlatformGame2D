using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemyMovement : MonoBehaviour
{

    /* private BoxCollider2D boxCollider2d;*/

    #region Public Variables;
    public AudioSource arrowHitSound;
    public AudioSource DeathSound;
    public Rigidbody2D rb;
    public Animator animator;
    public Animator playerAnimator;
    public Transform rayCast;
    public HealthBar healthBar; 
    public float attackRange = 2f;
    public float rayCastLength;
    public float attackDistance; // min distance for attack
    public float damage;
    public int currentHealth;
    #endregion

    #region Private Variables
    int direction = 1;
    int maxHealth = 100;
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance; // stores distance btw player and enemy
    private bool inRange; // check player in range
    #endregion

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        target = GameObject.Find("Player_Goblin").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            transform.localScale = new Vector2(5, 5);
        }
        else
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            transform.localScale = new Vector2(-5, 5);
        }
        Flip();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Collision with " + collision.tag);
        if (collision.tag == "Obstacles")
        {
            if (direction == 1)
            {
                direction = 2;
            }
            else
                direction = 1;

        }
        if (collision.tag == "Player")
        {
            target = collision.transform;
            inRange = true;
           // Debug.Log("player collied with skelton");
            Debug.Log("player entred in Seleton zone");
            collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
        }
    }
    public void TakeDemage(int demage)
    {
        currentHealth -= demage;
        healthBar.SetHealth(currentHealth);
        // play hurt animation
        StartCoroutine(SkeletonHurtAnimation());
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator SkeletonHurtAnimation()
    {
        // play hurt animation
        animator.SetBool("Sheild", true);
        arrowHitSound.Play();
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Sheild", false);

    }
    IEnumerator PlayerHurtAnimation()
    {
        // play hurt animation
       // playerAnimator.SetBool("Ishurt", true);
        yield return new WaitForSeconds(0.4f);
        //playerAnimator.SetBool("Ishurt", false);

    }
    IEnumerator SeletonAttackAnimation()
    {
        Debug.Log("In IEnumerator SeletonAttackAnimation()");
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack", false);

    }
    IEnumerator Die()
    {
        // Die Animation
        animator.SetBool("Death", true);
        Debug.Log("Skeleton died!");
        DeathSound.Play();
        yield return new WaitForSeconds(1f);
        // Disable the player 
        Destroy(gameObject);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }

        else if (distance < attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }

    private void Move()
    {
        anim.SetBool("CanWalk", true);
    }
    void Flip()
    {
        distance = Vector2.Distance(transform.position, target.position); // Checking distance btw player and enemy
        Vector3 rotation = transform.eulerAngles;
         rotation.x *= -1;
        if (distance >= 3)
        {
            inRange = false;
        }
         if(inRange && transform.position.x > target.position.x && direction == 1)
         {
             rotation.y = 180f;
             direction = 2;
             
         }
         else if (inRange &&  transform.position.x < target.position.x && direction == 2)
         {
            rotation.y = 180f;
            direction = 1;
         }
         else
         {
            rotation.y = 0f;
         }
         transform.eulerAngles = rotation;
    }
   
}
