using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPMelleSkeletonMovement : MonoBehaviour
{

    #region Public Variables;
 
    public Rigidbody2D rb;
    public Animator animator;
   
 
    public Transform rayCast;
    public Transform leftLimit;
    public Transform rightLimit;
    public HealthBar healthBar;
    public float attackRange = 2f;
    public float rayCastLength;
   // public float attackDistance; // min distance for attack
    public float stopDistance; //Enemy stop moving when distance < stop distance
    public float retreatDistance; //Enemy start moving back from player
    public int currentHealth;
    public int direction = 1;
    public int numberOfDamgeTake;
    public LootSystem lootSystem;
    public MPCameraController mPCameraController;
    #endregion

    #region Private Variables
    private MPEnemyShield shield;
    private int maxHealth = 100;
    private float distance; // stores distance btw player and enemy
    private bool inRange; // check player in range
    #endregion

    private void Awake()
    {
        SelectTarget();
    }
    private void Start()
    {
        Time.timeScale = 1f;
        numberOfDamgeTake = 0;
        mPCameraController = GameObject.Find("Camera").GetComponent<MPCameraController>();
        shield = GetComponent<MPEnemyShield>();
        lootSystem = GetComponent<LootSystem>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        stopDistance = 6.5f;
        retreatDistance = 5.5f;
    }
    void Update()
    {
        if (!InsideOfLimit())
        {
            SelectTarget();
        }
    }
    private void LateUpdate()
    {
        if (mPCameraController.targets.Count == 0)
            return;
        else
            MovingTowardsPlayers();
    }
    void MovingTowardsPlayers()
    {
        if (mPCameraController.targets.Count > 1)
        {
            /*
         ----------- enemy moving towards player----------
     */

            if (Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) > stopDistance &&
                (Vector2.Distance(transform.position, mPCameraController.targets[1].transform.position) > stopDistance) && currentHealth > 0)
            {
                animator.SetFloat("Speed", Mathf.Abs(40));
               // Debug.Log(" enemy moving towards player");
                if (direction == 1)
                {
                    rb.velocity = new Vector2(3, rb.velocity.y);
                    transform.localScale = new Vector2(1, 1);
                }
                else
                {
                    rb.velocity = new Vector2(-3, rb.velocity.y);
                    transform.localScale = new Vector2(-1, 1);
                }
                //Debug.Log("transform pos" + transform.position);
                Flip();
            }
            /*
                -----------if enemy near enough but not much near stop  moving----------
             */
            else if ((Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) < stopDistance && Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) > retreatDistance) ||
                    (Vector2.Distance(transform.position, mPCameraController.targets[1].transform.position) < stopDistance && Vector2.Distance(transform.position, mPCameraController.targets[1].transform.position) > retreatDistance))
            {
                //Debug.Log(" if enemy near enough but not much near stop  moving-");
                animator.SetFloat("Speed", Mathf.Abs(0));
                rb.velocity = new Vector2(0, 0);
                transform.position = this.transform.position;
                Flip();
            }
            /*
                -----------enemy moving away from player if it is very near to player----------
             */
            else if ((Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) < retreatDistance) ||
                    (Vector2.Distance(transform.position, mPCameraController.targets[1].transform.position) < retreatDistance))
            {
                //Debug.Log(" enemy moving away from player if it is very near to player-");
                if(transform.position.x <  mPCameraController.targets[0].transform.position.x)
                {
                    Debug.Log("  player is on left side -");
                    if (direction == 1)
                    {

                        rb.velocity = new Vector2(-3, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(3, rb.velocity.y);
                    }
                    Flip();
                }
                else
                {
                    Debug.Log("  player is on right side -");
                    if (direction == 1)
                    {

                        rb.velocity = new Vector2(3, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(-3, rb.velocity.y);
                    }
                    Flip();
                }
               
            }
            else
            {
             //   Debug.Log(" Else-");
                if (direction == 1)
                {
                    rb.velocity = new Vector2(3, rb.velocity.y);
                    transform.localScale = new Vector2(1, 1);
                }
                else
                {
                    rb.velocity = new Vector2(-3, rb.velocity.y);
                    transform.localScale = new Vector2(-1, 1);
                }
                //Debug.Log("transform pos" + transform.position);
                Flip();
            }
        }
        else
        {
            /*----------- enemy moving towards player---------- */

            if (Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) > stopDistance  )
            {
                animator.SetFloat("Speed", Mathf.Abs(40));
               // Debug.Log(" enemy moving towards player");
                if (direction == 1)
                {
                    rb.velocity = new Vector2(3, rb.velocity.y);
                    transform.localScale = new Vector2(1, 1);
                }
                else
                {
                    rb.velocity = new Vector2(-3, rb.velocity.y);
                    transform.localScale = new Vector2(-1, 1);
                }
                //Debug.Log("transform pos" + transform.position);
                Flip();
            }
            /*
                -----------if enemy near enough but not much near stop  moving----------
             */
            else if ((Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) < stopDistance && Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) > retreatDistance) )
            {
               // Debug.Log(" if enemy near enough but not much near stop  moving-");
                animator.SetFloat("Speed", Mathf.Abs(0));
                rb.velocity = new Vector2(0, 0);
                transform.position = this.transform.position;
                Flip();
            }
            /*
                -----------enemy moving away from player if it is very near to player----------
             */
            else if ((Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) < retreatDistance) )
            {
               // Debug.Log(" enemy moving away from player if it is very near to player-");
                if (direction == 1)
                {

                    rb.velocity = new Vector2(-3, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(3, rb.velocity.y);
                }
                Flip();
            }
            else
            {
               // Debug.Log(" Else-");
                if (direction == 1)
                {
                    rb.velocity = new Vector2(3, rb.velocity.y);
                    transform.localScale = new Vector2(1, 1);
                }
                else
                {
                    rb.velocity = new Vector2(-3, rb.velocity.y);
                    transform.localScale = new Vector2(-1, 1);
                }
                //Debug.Log("transform pos" + transform.position);
                Flip();
            }
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
            else if (direction == 2)
                direction = 1;

        }
     

    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            Debug.Log("Damaging the enemy :- shield.ActiveShield " + shield.ActiveShield);
            if (numberOfDamgeTake > 3)
                StartCoroutine(SheildTimer());
            if (!shield.ActiveShield || (transform.position.x > mPCameraController.targets[0].transform.position.x && direction == 1) || (transform.position.x < mPCameraController.targets[0].transform.position.x && direction == 2))
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);

                StartCoroutine(SkeletonHurtAnimation());
                if (currentHealth <= 0)
                {
                    rb.velocity = new Vector2(0, 0);
                    transform.position = this.transform.position;
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
    public void Flip()
    {
        if (mPCameraController.targets.Count > 1)
        {
            distance = Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position); // Checking distance btw player 1 and enemy
            float dis2 = Vector2.Distance(transform.position, mPCameraController.targets[1].transform.position); // Checking distance btw player 2 and enemy
            Vector3 rotation = transform.eulerAngles;
            rotation.x *= -1;
            if (distance >= 5 || dis2 >= 5)
            {
                inRange = false;
            }
            else
                inRange = true;
            if ((inRange && transform.position.x > mPCameraController.targets[0].transform.position.x && direction == 1) || (inRange && transform.position.x > mPCameraController.targets[1].transform.position.x && direction == 1))
            {
                rotation.y = 180f;
                direction = 2;
                Debug.Log("Skeleton Flip to left");

            }
            else if ((inRange && transform.position.x < mPCameraController.targets[0].transform.position.x && direction == 2) ||
                (inRange && transform.position.x < mPCameraController.targets[0].transform.position.x && direction == 2))
            {
                rotation.y = 180f;
                direction = 1;
                Debug.Log("Skeleton Flip to right");
            }
            else
            {
                rotation.y = 0f;
            }
            transform.eulerAngles = rotation;
        }
        else
        {
            distance = Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position); // Checking distance btw player 1 and enemy
            Vector3 rotation = transform.eulerAngles;
            rotation.x *= -1;
            if (distance >= 5 )
            {
                inRange = false;
            }
            else
                inRange = true;
            if (inRange && transform.position.x > mPCameraController.targets[0].transform.position.x && direction == 1)
            { 
                rotation.y = 180f;
                direction = 2;
                Debug.Log("Skeleton Flip to left");

            }
            else if (inRange && transform.position.x < mPCameraController.targets[0].transform.position.x && direction == 2)
            {
                rotation.y = 180f;
                direction = 1;
                Debug.Log("Skeleton Flip to right");
            }
            else
            {
                rotation.y = 0f;
            }
            transform.eulerAngles = rotation;
        }
    }

    void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);
        Vector3 rotation = transform.eulerAngles;
       Debug.Log(distanceToLeft + " :: " + distanceToRight);
        if (distanceToLeft > distanceToRight)
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
   
       // Debug.Log(transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x);
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }
}
