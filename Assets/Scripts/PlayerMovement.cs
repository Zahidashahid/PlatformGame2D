using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    [SerializeField] private LayerMask m_WhatIsGround;
    public Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
   
    public Animator animator;
    public Animator eagle_animator;
    
    bool jump ;
    bool crouch = false;

    int jumpCount = 0;
    private int direction = 2;
    public int currentHealth;
    public int maxHealth = 100;

    private float dashTime = 40f;
    public float attackRange = 0.5f;
    public float attackRate = 1f; //one attack per second
    public float nextAttackTime = 0f;
    public float runSpeed = 60f;
    float horizontalMove = 0f;

    public Transform attackPoint;
    public Transform weaponAttackPoint;
    public LayerMask enemyLayers;

    private void Awake()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        //Eagle_animator = GameObject.FindGameObjectWithTag("Enemy").transform<Animator>;
        currentHealth = maxHealth;

    }
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        // Move Player back
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            direction = 1; 
        }
        // Move Player Forward
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            direction = 2;
        }
        // Jump Player if on ground ,  double jump
        if ((jumpCount < 2 ||  IsGrounded() == null) && (Input.GetKeyDown(KeyCode.Space)))
        {
            jumpCount++;
            //rb.velocity = new Vector2(rb.velocity.x, 11f);

            rb.velocity = new Vector2(rb.velocity.x, 12f);
            animator.SetBool("IsJumping", true);
            Debug.Log(" jump count is " + jumpCount);
            
            if (jumpCount > 2)
            {
                jumpCount = 0;
            }


        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space) )   //when  Space key are up. 
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                animator.SetBool("IsJumping", false);
                jump = true;
                
            }
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("IsCrouching", true);
            crouch = true;
        }
        else
        {
            crouch = false;
        }
        
        // Dash move 
        if (Input.GetKey(KeyCode.P))
        {
            animator.SetFloat("Speed", Mathf.Abs(40));
            if (direction == 1)
            {
                rb.velocity = new Vector2(-40, rb.velocity.y);
            }
            else if (direction == 2)
            {
                rb.velocity = new Vector2(40, rb.velocity.y);
            }
        }


        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("attack Called");
                //eagle_animator.SetTrigger("Death");
                // StartCoroutine(Attack());
                Attack();
                nextAttackTime =  Time.time + 1f / attackRate;

            }
        }
      

    }
     void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    public void OnLanding()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        Debug.Log("In OnLanding method");
        animator.SetBool("IsJumping", false);
        jumpCount = 0;
    }
    public void OnCrouching(bool isCrouching)
    {
        //Debug.Log("In IsCrouching method");
        animator.SetBool("IsCrouching", isCrouching);

    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, m_WhatIsGround);
       // Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
    /// <summary>
    /// Attack on skeleton enemy
    /// </summary>
    void Attack() //IEnumerator
    {
        //Deteck enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(weaponAttackPoint.position, attackRange, enemyLayers);
        //Demage Them
        foreach (Collider2D enemy in hitEnemies)
        {
           // Debug.Log("We hit " + enemy.name);
            if (enemy.name == "Skeleton")
            {
                enemy.GetComponent<SkeletonEnemyMovement>().TakeDemage(40);
            }
            //eagle_animator.SetTrigger("Death");
            // yield return new WaitForSeconds(1);
            else
                Destroy(enemy.gameObject);
        }
        
    }
    //Show Attack point oject in scene for better Visibility
    void OnDrawGizmoSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void TakeDemage(int demage)
    {
        currentHealth -= demage;
        // play hurt animation
        StartCoroutine(HurtAnimation());
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    IEnumerator HurtAnimation()
    {
        // play hurt animation
        animator.SetBool("Ishurt", true);
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("Ishurt", false);
   
    }
    void Die()
    {
        // Die Animation
        animator.SetBool("Ishurt", true);
        Debug.Log("Player died!");

        // Disable the player
        FindObjectOfType<GameUIScript>().GameOver();
    }

    
}
