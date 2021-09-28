using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemyMovement : MonoBehaviour
{

    /* private BoxCollider2D boxCollider2d;*/

    public Rigidbody2D rb;
    public Animator animator;
    public Animator playerAnimator;

    public int maxHealth = 100;
    public int currentHealth;
    int direction = 1;

    #region Public Variables;
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance; // min distance for attack
    public float moveSpeed;
    public float timer; //time for cooldown btw attacks
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance; // stores distance btw player and enemy
    private bool attackMode;
    private bool inRange; // check player in range
    private bool cooling;
    private float intTimer;
    #endregion


    private void Awake()
    {
        // boxCollider2d = GetComponent<BoxCollider2D>();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {

        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, rayCastMask);
            RaycastDebugger();

        }
        //When Player is detected
        if (hit.collider != null)
        {
            EnemyLogic();
            inRange = true;
        }
        else if (hit.collider == null)
        {

            inRange = false;
        }
        if (inRange == false)
        {
            //animation of ideal/ walk
            anim.SetBool("CanWalk", false);
            StopAttack();

        }
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
            target = collision.gameObject;
            inRange = true;
            Debug.Log("player collied with skelton");

        }


    }

    public void TakeDemage(int demage)
    {
        currentHealth -= demage;

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
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Sheild", false);

    }
    IEnumerator PlayerHurtAnimation()
    {
        // play hurt animation
        playerAnimator.SetBool("Ishurt", true);
        yield return new WaitForSeconds(0.4f);
        playerAnimator.SetBool("Ishurt", false);

    }
    IEnumerator SeletonAttackAnimation()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack", false);

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

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }

        else if (distance < attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > attackDistance)
        {
            Move();
            StopAttack();

        }
        else if (attackDistance >= distance && cooling == false)
        {
            anim.SetBool("Attack", false);
            // StartCoroutine(Attack());
            Attack();

        }
        if (cooling)
        {
            CoolDown();
            anim.SetBool("Attack", false);


        }
    }
    private void Move()
    {
        anim.SetBool("CanWalk", true);
        /*  if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack1"))
          {
              Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
              transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
          }*/
    }
    // IEnumerator Attack()
    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("CanWalk", false);
        // anim.SetBool("Attack", true);

        StartCoroutine(SeletonAttackAnimation());
        StartCoroutine(PlayerHurtAnimation());
        // yield return new WaitForSeconds(0.05f);
        /*
                playerAnimator.SetBool("Ishurt", false);
                anim.SetBool("CanWalk", true);
                anim.SetBool("Attack", false);*/
    }
    private void StopAttack()
    {
        cooling = false;
        attackMode = false;
        // anim.SetBool("CanWalk", true);
        anim.SetBool("Attack", false);
    }
    public void TriggerCooling()
    {
        cooling = true;

    }
    void CoolDown()
    {
        //Debug.Log("In coolDown Function");
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
}
