using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerMovement : MonoBehaviour
{

    public HealthBar healthBar;
    public CharacterController2D controller;
    [SerializeField] private LayerMask m_WhatIsGround;
    public Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
   
    public Animator animator;
    public Animator eagle_animator;
    public Animator skeleton_animator;
    /*public AudioSource jumpSound;
    public AudioSource DeathSound;
    public AudioSource meleeAttackSound;*/
    public AudioSource bgSound;
    bool jump ;
    bool crouch = false;
    bool grounded;
    int jumpCount = 0;
    public int direction = 2;
    public int currentHealth;
    public int maxHealth = 100;
    public int lifes ;

    private float dashTime = 40f;
    public float attackRange = 0.5f;
    public float attackRate = 1f; //one attack per second
    public float nextAttackTime = 0f;
    public float runSpeed = 60f;
    float horizontalMove = 0f;

    public Transform attackPoint;
    public Transform weaponAttackPoint;
    public LayerMask enemyLayers;

    private GameMaster gm;
    public TMP_Text lifesText;
    private void Awake()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        lifes = 3;
        //bgSound.Play();
    }
    private void Start()
    {

        bgSound = GameObject.FindGameObjectWithTag("BGmusicGameObject").GetComponent<AudioSource>();
        //Eagle_animator = GameObject.FindGameObjectWithTag("Enemy").transform<Animator>;
        currentHealth = maxHealth;
        lifes = PlayerPrefs.GetInt("Lifes");
        currentHealth = PlayerPrefs.GetInt("CurrentHealth");
        lifesText.text = "X " + lifes;
        Debug.Log("current health of player is " + currentHealth);
        Debug.Log("Max health of player is " + maxHealth);
        healthBar.SetMaxHealth(maxHealth);
        grounded = true;
        // bgSound.Play();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        if(lifes == 3 && currentHealth == 100)
        {
            return;
        }
        else
            transform.position = gm.lastCheckPointPos;
    }
    private void Update()
    {
        // Debug.Log("Is Grounded! "+ grounded);
        // Move Player back
        CheckGamePaused();
        if ( Input.GetKey(KeyCode.LeftArrow))// && grounded
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            animator.SetFloat("Speed", Mathf.Abs(40));
            direction = 1; 
        }
        // Move Player Forward
        else if ( Input.GetKey(KeyCode.RightArrow))//&& grounded
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            animator.SetFloat("Speed", Mathf.Abs(40));
            direction = 2;
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(0));
        }
        // Jump Player if on ground ,  double jump
        if ((jumpCount < 2 ||  IsGrounded()) && (Input.GetKeyDown(KeyCode.Space)))
        {
            jumpCount++;
            grounded = false;
            //rb.velocity = new Vector2(rb.velocity.x, 11f);
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            animator.SetBool("IsJumping", true);
            Debug.Log(" jump count is " + jumpCount);
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.jumpSound);
            animator.SetFloat("Speed", Mathf.Abs(40));
            if (direction == 1)
            {
                rb.velocity = new Vector2(-5, rb.velocity.y);
            }
            else if (direction == 2)
            {
                rb.velocity = new Vector2(5, rb.velocity.y);
            }
            animator.SetFloat("Speed", Mathf.Abs(40));
            if (jumpCount > 2)
            {
                jumpCount = 0;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space) )   //when  Space key is up. 
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                animator.SetBool("IsJumping", false);
                jump = true;
                
            }
        }
        // Dash move 
        if (Input.GetKey(KeyCode.P) && grounded)
        {
            animator.SetFloat("Speed", Mathf.Abs(40));
            if (direction == 1)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
            }
            else if (direction == 2)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("attack Called");
                
                //eagle_animator.SetTrigger("Death");
                StartCoroutine(Attack());
                //Attack();
                nextAttackTime =  Time.time + 1f / attackRate;

            }
        }

        //Debug.Log("player i moving in direction " + direction);
    }
   /*  void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }*/
    public void OnLanding()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
       // Debug.Log("In OnLanding method");
        animator.SetBool("IsJumping", false);
        grounded = true;
        jumpCount = 0;
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
    IEnumerator Attack() //Melle Attack by player
    {
        animator.SetBool("Attack1", true);
        
        yield return new WaitForSeconds(0.5f);
        SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.meleeAttackSound);
        animator.SetBool("Attack1", false);
        //Deteck enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(weaponAttackPoint.position, attackRange, enemyLayers);
        //Demage Them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            if (enemy.name == "Skeleton" || enemy.tag == "Skeleton" )
            {
                enemy.GetComponent<SkeletonEnemyMovement>().TakeDemage(40);
                StartCoroutine(SkeletonSheildtAnimation());
            }
            //eagle_animator.SetTrigger("Death");
            // yield return new WaitForSeconds(1);
            else
                Destroy(enemy.gameObject);
            break;
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
        PlayerPrefs.SetInt("CurrentHealth" , currentHealth);
        healthBar.SetHealth(currentHealth);
        // play hurt animation
        // StartCoroutine(HurtAnimation());
        if (currentHealth <= 0)
        {
            PlayerPrefs.SetInt("CurrentHealth", 100);
            lifes -= 1;
            lifesText.text = "X " + lifes;
            PlayerPrefs.SetInt("Lifes", lifes);
        }
         if (currentHealth <= 0 && lifes <= 0)
        {
            // bgSound.Stop();
            PlayerPrefs.SetInt("CurrentHealth", 100);
            PlayerPrefs.SetInt("Lifes", 3);
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.deathSound);
            StartCoroutine( Die() );
            this.enabled = false;
        }
        else if (currentHealth <= 0)
        {
            StartCoroutine(OnOneDeath());
        }
    }
   /* IEnumerator HurtAnimation()
    {
        // play hurt animation
        animator.SetBool("Ishurt", true);
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("Ishurt", false);
    }*/
    IEnumerator SkeletonSheildtAnimation()
    {
        // play hurt animation
        skeleton_animator.SetBool("sheild", true);
        yield return new WaitForSeconds(0.4f);
        skeleton_animator.SetBool("sheild", false);
    }
    public IEnumerator Die()
    {
        // Die Animation
        animator.SetBool("IsDied", true);
        Debug.Log("Player died!");
        bgSound.Stop();
        yield return new WaitForSeconds(0.3f);
       // animator.SetBool("IsDied", false);
        // Disable the player
        FindObjectOfType<GameUIScript>().GameOver();
      
        SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.deathSound);

    }
    
    public IEnumerator OnOneDeath()
    {
        currentHealth = 100;
        healthBar.SetHealth(currentHealth);
        // Die Animation
        animator.SetBool("IsDied", true);
        Debug.Log("Player died!");
        SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.deathSound);
        // bgSound.Stop();
        yield return new WaitForSeconds(0.3f);
        // Set the player on check point position
        animator.SetBool("IsDied", false);
        transform.position = gm.lastCheckPointPos;
    }
    public int PlayerMovingDirection()
    {
        if (direction == 1)
            return 1;
        else
            return 2;
    }

    void CheckGamePaused()
    {
        if (PauseGame.isGamePaused)
        {
            //bgSound.pitch *= .5f;
        }
       /* else
            bgSound.pitch = 1f;*/
    }

    public void Reset()
    {
        lifes = 0;
        currentHealth = 100;
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("CurrentHealth", 100);
        PlayerPrefs.SetInt("Lifes", 3);
    }
}
