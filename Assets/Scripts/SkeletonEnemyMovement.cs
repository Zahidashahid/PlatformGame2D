using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemyMovement : MonoBehaviour
{

    /* private BoxCollider2D boxCollider2d;*/

    #region Public Variables;
    /*
    public AudioSource arrowHitSound;
    public AudioSource DeathSound;*/
    public Rigidbody2D rb;
    public Animator animator;
    public Animator playerAnimator;
    public Transform rayCast;
    public Transform leftLimit;
    public Transform rightLimit;
    public HealthBar healthBar; 
    public float attackRange = 2f;
    public float rayCastLength;
    public float attackDistance; // min distance for attack
    public float damage;
    public float stopDistance; //Enemy stop moving when distance < stop distance
    public float retreatDistance; //Enemy start moving back from player
    public int currentHealth;
    public int direction = 1;
    public int numberOfDamgeTake;
    public LootSystem lootSystem;
    #endregion

    #region Private Variables
    private EnemyShield shield;
    private int maxHealth = 100;
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    
    private float distance; // stores distance btw player and enemy
    private bool inRange; // check player in range
    #endregion

    private void Awake()
    {
        anim = GetComponent<Animator>();
        SelectTarget();
    }
    private void Start()
    {
        numberOfDamgeTake = 0;
        shield = GetComponent<EnemyShield>();
        lootSystem = GetComponent<LootSystem>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        target = GameObject.Find("Player_Goblin").transform;
        stopDistance = 5;
        retreatDistance = 3;
    }

    void Update()
    {
        if (!InsideOfLimit())
        {
            SelectTarget();
        }
        /*
           ----------- enemy moving towards player----------
        */
        if (Vector2.Distance(transform.position, target.position) > stopDistance && currentHealth > 0)
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
            //Debug.Log("transform pos" + transform.position);
            Flip();
        }
        /*
            -----------if enemy near enough but not much near stop  moving----------
         */
        else if (Vector2.Distance(transform.position, target.position) < stopDistance && Vector2.Distance(transform.position, target.position) > retreatDistance) 
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = this.transform.position;
            Flip();
        }
        /*
           -----------enemy moving away from player if it is very near to player----------
        */
        else if (Vector2.Distance(transform.position, target.position) <  retreatDistance)
        {
            if(direction == 1)
            {
              
                rb.velocity = new Vector2(-3, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(3, rb.velocity.y);
            }
            Flip();
            //transform.localScale = new Vector2(5, 5);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {/*
         Debug.Log("Collision with " + collision.tag);
         Debug.Log("Collision name " + collision.name);*/
        if (collision.tag == "Obstacles" || collision.tag == "Skeleton")
        {

            if (direction == 1)
            {
                direction = 2;
            }
            else if(direction == 2)
                direction = 1;

        }
        if (collision.tag == "Player")
        {
            target = collision.transform;
            inRange = true;
           // Debug.Log("player collied with skelton");
           // Debug.Log("player entred in Seleton zone");
           // collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
        }
    }
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            Debug.Log("Damaging the enemy :- shield.ActiveShield " + shield.ActiveShield);
            if (numberOfDamgeTake > 3)
                StartCoroutine(SheildTimer());
            if (!shield.ActiveShield || (transform.position.x > target.position.x && direction == 1) && (transform.position.x < target.position.x && direction == 2))
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth); 
               
                StartCoroutine(SkeletonHurtAnimation());
                if (currentHealth <= 0)
                {
                    rb.velocity = new Vector2(0, 0);
                    transform.position = this.transform.position;
                    // transform.localScale = new Vector2(0, 0);
                    /* Debug.Log("transform " + this.name);
                     Debug.Log("position " + this.transform.position);*/

                    lootSystem.Spawnner(transform);
                    
                    StartCoroutine(Die());

                }
            }
            else
                numberOfDamgeTake += 1;
        }
 
    }
    public IEnumerator SkeletonHurtAnimation()
    {
        /*---------play hurt animation--------------*/
        
        animator.SetBool("Hurt", true);
        SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.arrowHitSound);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Hurt", false);

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
        animator.SetBool("Hurt", false);
        // Die Animation
        animator.SetBool("Death", true);
        Debug.Log("Skeleton died!");
        SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.deathSound);
        yield return new WaitForSeconds(1f);
        // Disable the player 
        Destroy(gameObject);
    }
    IEnumerator SheildTimer()
    {
        shield.ActiveShield = false;
        animator.SetBool("Sheild", false);
        yield return new WaitForSeconds(5f);
        shield.ActiveShield = true;
        animator.SetBool("Sheild", true);
        numberOfDamgeTake = 0;
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
    public void Flip()
    {
        
        distance = Vector2.Distance(transform.position, target.transform.position); // Checking distance btw player and enemy
        
        Vector3 rotation = transform.eulerAngles;
         rotation.x *= -1;
        if (distance >= 5)
        {
            inRange = false;
        }
        else
            inRange = true;
        /*
            direction 2 means skeleton moving towards left vise versa
            transform.position.x i.e skeleton position > target.position.x  i.e player position means player is on right side of enemy
        */
        /*Debug.Log("distance " + distance);
        Debug.Log("inRange for Flip " + inRange);
        Debug.Log("direction " + direction);
        Debug.Log("transform.position.x " + transform.position.x);
        Debug.Log("target.position.x " + target.position.x);*/
        if (inRange && transform.position.x > target.position.x && direction == 1) 
        {
            rotation.y = 180f;
            direction = 2;
            //Debug.Log("Skeleton Flip " );

        }
        else if (inRange &&  transform.position.x < target.position.x && direction == 2)
        {
            rotation.y = 180f;
            direction = 1;
            //Debug.Log("Skeleton Flip ");
        }
        else
        {
        rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
        //Debug.Log("transform.eulerAngles " + transform.eulerAngles);

    }

    void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);
        Vector3 rotation = transform.eulerAngles;
        //Debug.Log(distanceToLeft + " " + distanceToRight);
        if(distanceToLeft > distanceToRight)
        {
            rotation.y = 180f;
            direction = 2;
        }
        else
        {
            rotation.y = 180f;
            direction = 1;
        }

    }
    bool InsideOfLimit()
    {
        /*
        Debug.Log(transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x);*/
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }
}
