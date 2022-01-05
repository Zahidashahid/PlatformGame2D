using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class MultiPlayer2 : MonoBehaviour
{
    PlayerController controls;
    Vector3 move;
    Vector3 m;
    public HealthBar healthBar;
    [SerializeField] public LayerMask m_WhatIsGround;
    public Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;

     Animator animator;
     Transform transformObj;
    public AudioSource bgSound;
    
   
    int jumpCount = 0;
    public int direction = 2;
    public int currentHealth;
    public int maxHealth = 100;
    public int lifes;
    public int numberOfDamgeTake;

    public float attackRange =3f;
    public float attackRate = 1f; //one attack per second
    public float nextAttackTime = 0f;
    float runSpeed = 5f;
  

    public Transform attackPoint;
    public Transform weaponAttackPoint;
    public LayerMask enemyLayers;

    private Shield shield; //Player Shield
    private GameMaster gm;
    public TMP_Text lifesText;
    GameUIScript gameUIScript;
    public LootSystem lootSystem;
    MPCameraController mPCameraController;
    private void Awake()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();

        mPCameraController = GameObject.Find("Camera").GetComponent<MPCameraController>();
        lifes = 3;
        controls = new PlayerController();
        controls.Gameplay.Multiplayer2Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Multiplayer2Movement.canceled += ctx => move = Vector2.zero;
        controls.Gameplay.Multiplayer2Jump.performed += ctx => JumpPlayer();
        /*    controls.Gameplay.RightMove.performed +=ctx   => MovePlayerRight();
            controls.Gameplay.LeftMove.performed +=ctx   => MoveplayerLeft();
           */
        controls.Gameplay.MelleAttackByKeyboard.performed += ctx => MelleAttack();

        controls.Gameplay.MPPlayeer2Dashmove.performed += ctx => DashMovePlayer();
        //bgSound.Play();
    }
    private void Start()
    {
        numberOfDamgeTake = 0;
        direction = 2;
        lootSystem = GetComponent<LootSystem>();
        shield = GetComponent<Shield>();
        animator = GetComponent<Animator>(); ;
        transformObj = GetComponent<Transform>();
        bgSound = GameObject.FindGameObjectWithTag("BGmusicGameObject").GetComponent<AudioSource>();
        Debug.Log("Animator is assign " + animator.name);
        currentHealth = maxHealth;
      /*  lifes = PlayerPrefs.GetInt("Lifes");
        currentHealth = PlayerPrefs.GetInt("CurrentHealth");*/
        lifesText.text = "X " + lifes;
        /*Debug.Log("current health of player is " + currentHealth);
        Debug.Log("Max health of player is " + maxHealth);*/
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        // bgSound.Play();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    private void FixedUpdate()
    {
        // Debug.Log("Is Grounded! "+ grounded);
        /* ----------------Move Player back-------------------- */
        CheckGamePaused();
        m = new Vector3(move.x, move.y) * 10f * Time.deltaTime;
         

        if (move.x == 0 && move.y == 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(0));
        }

        else if (move.x > 0)
        {
            MovePlayerRight();
        }
        else if (move.x < 0)
        {
            MoveplayerLeft();
        }
      

    }
    void MovePlayerRight()
    {
        rb.velocity = new Vector2(runSpeed, rb.velocity.y);
        transformObj.localScale = new Vector2(1, 1);
        animator.SetFloat("Speed", Mathf.Abs(40));
        direction = 2;
        MevementLogicRespectTOOtherPlayer();
    }
    void MoveplayerLeft()
    {
        rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
        transformObj.localScale = new Vector2(-1, 1);
        animator.SetFloat("Speed", Mathf.Abs(40));
        direction = 1;
        MevementLogicRespectTOOtherPlayer();
    }
    void JumpPlayer()
    {
        if (jumpCount < 2 || IsGrounded())
        {

            jumpCount++;
            //rb.velocity = new Vector2(rb.velocity.x, 11f);
            rb.velocity = new Vector2(rb.velocity.x, 8f);
            //animator.SetBool("IsJumping", true);
            Debug.Log(" jump count is " + jumpCount);
            Debug.Log(" IsGrounded() is " + IsGrounded());
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.jumpSound);
            // animator.SetFloat("Speed", Mathf.Abs(40));
       
            if (direction == 1)
            {
                rb.velocity = new Vector2(-8, rb.velocity.y);
                StartCoroutine(Jumping());
            }
            else if (direction == 2)
            {
                rb.velocity = new Vector2(8, rb.velocity.y);
                StartCoroutine(Jumping());
            }
            if (jumpCount > 2)
            {
                jumpCount = 0;
            }

        }
        else
        {
            //rb.velocity = new Vector2(rb.velocity.x, 0f);
            animator.SetBool("IsJumping", false);
            // jump = true;

        }
    }
    void DashMovePlayer()
    {
        if (IsGrounded())
        {
            Debug.Log("DashMovePlayer() Grounded " + IsGrounded());
            animator.SetFloat("Speed", Mathf.Abs(40));
            //animator.SetBool("IsJumping", true);
            if (direction == 1)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                transformObj.localScale = new Vector2(-1, 1);
                animator.SetFloat("Speed", Mathf.Abs(40));
            }
            else if (direction == 2)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                transformObj.localScale = new Vector2(1, 1);
                animator.SetFloat("Speed", Mathf.Abs(40));
            }
        }
    }
  
    void MelleAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            StartCoroutine(Attack());
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
    public void OnLanding()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        // Debug.Log("In OnLanding method");
        animator.SetBool("IsJumping", false);
        jumpCount = 0;
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, m_WhatIsGround);
         Debug.Log("IsGrounded " +raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
    /* <summary>
       ------------Attack on skeleton enemy--------------------------------------
    </summary> */
    IEnumerator Attack() //Melle Attack by player
    {
        animator.SetBool("Attack1", true);
        Debug.Log("Attack " );
        yield return new WaitForSeconds(0.5f);
       // SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.meleeAttackSound);
        animator.SetBool("Attack1", false);
        //string difficultyLevel = PlayerPrefs.GetString("DifficultyLevel");
        /*   ----------Deteck enemies in range-------------*/
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(weaponAttackPoint.position, attackRange, enemyLayers);
       /* -----------------damage Them-------------------*/
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("enemy.name " + enemy.name);
            if (enemy.name == "Skeleton" || enemy.tag == "Skeleton")
            {
                enemy.GetComponent<MPMelleSkeletonMovement>().TakeDamage(30);
            }
            else if (enemy.name == "Range Attack Skeleton" || enemy.tag == "RangedAttackSkeleton")
            {
                enemy.GetComponent<MPRangeAttackMovement>().TakeDamage(30);
            }
            else if (enemy.name == "Player1")
            {
                enemy.GetComponent<MultiPlayer1>().TakeDamage(30);
            }
            else
                break;
        }

    }
    /*-------------Show Attack point oject in scene for better Visibility--------------------*/
    void OnDrawGizmoSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0 && lifes > 0)
        {

            if (numberOfDamgeTake > 3)
                StartCoroutine(SheildTimer());
            if (animator.GetBool("Shield") == false)
            {
                currentHealth -= damage;
             /*   PlayerPrefs.SetInt("CurrentHealth", currentHealth);*/
                healthBar.SetHealth(currentHealth);
                StartCoroutine(Hurt());
                // play hurt animation
                if (currentHealth <= 0)
                {
             /*       PlayerPrefs.SetInt("CurrentHealth", 100);*/
                    lifes -= 1;
                    lifesText.text = "X " + lifes;
               /*     PlayerPrefs.SetInt("Lifes", lifes);*/
                }
                if (currentHealth <= 0 && lifes <= 0)
                {
                    // bgSound.Stop();
          /*          PlayerPrefs.SetInt("CurrentHealth", 100);
                    PlayerPrefs.SetInt("Lifes", 3);*/
                    SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.deathSound);
                    StartCoroutine(Die());
                    this.enabled = false;
                }
                else if (currentHealth <= 0)
                {
                    StartCoroutine(Die());
                    //StartCoroutine(OnOneDeath());
                }
            }
            else
                numberOfDamgeTake += 1;
        }
    }
    IEnumerator SheildTimer()
    {
        shield.ActiveShield = false;
        shield.shieldGO.SetActive(false);
        yield return new WaitForSeconds(5f);
        shield.ActiveShield = true;
        shield.shieldGO.SetActive(true);
        numberOfDamgeTake = 0;
    }
    IEnumerator Hurt()
    {
        animator.SetBool("IsHurt", true);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("IsHurt", false);
    } 
    IEnumerator Jumping()
    {
        animator.SetBool("IsJumping", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsJumping", false);
    }
    public IEnumerator Die()
    {
        // Die Animation
        animator.SetBool("IsDied", true);
        Debug.Log("Player died!");
        //bgSound.Stop();
        yield return new WaitForSeconds(0.3f);
        // animator.SetBool("IsDied", false);
        // Disable the player
        // FindObjectOfType<GameUIScript>().GameOver();

        lootSystem.Spawnner(transform);
        Destroy(gameObject);
        SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.deathSound);
    }

    public IEnumerator OnOneDeath()
    {
        currentHealth = 100;
        healthBar.SetHealth(currentHealth);
        animator = GetComponent<Animator>(); ;
        // Die Animation
        animator.SetBool("IsDied", true);
        Debug.Log("Player died!");
        Debug.Log(" died!" + animator.GetBool("IsDied"));
        // PlayerPrefs.SetInt("ArrowPlayerHas", 10);
        SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.deathSound);
        Debug.Log("Sound played!");
        // bgSound.Stop();
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Wait End!");
         /*----------Set the player on check point position--------------*/
        animator.SetBool("IsDied", false);
        Debug.Log("Player Reactive!");
        transformObj.position = gm.lastCheckPointPos;
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

    void MevementLogicRespectTOOtherPlayer()
    {
        if (mPCameraController.targets.Count > 1)
        {
            float retreatDistance = 3.5f;
            float stopDistance = 5;
             Debug.Log("MP2 Distance " + Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position));
            /*
           -----------if enemy near enough but not much near stop  moving----------
        */
          /*  if (Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) < stopDistance &&
                Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) > retreatDistance)
            {
                Debug.Log("Stop moving from p1");
                //rb.velocity = new Vector2(0, 0);
               // transform.position = this.transform.position;

            }*/
            /*
               -----------enemy moving away from player if it is very near to player----------
            */
             if (Vector2.Distance(transform.position, mPCameraController.targets[0].transform.position) < retreatDistance)
            {
                Debug.Log(" moving away from player 1 ");
                Debug.Log(transform.position.x + " pos  player 1 " + mPCameraController.targets[0].name);
                if (transform.position.x >= mPCameraController.targets[0].transform.position.x)
                {
                    Debug.Log(transform.position.x + " pos  player 1 " + mPCameraController.targets[0].transform.position.x);
                    if (direction == 1)
                    {

                        rb.velocity = new Vector2(5, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(-5, rb.velocity.y);
                    }
                }
                else
                {
                    Debug.Log(transform.position.x + "   player 1 " + mPCameraController.targets[0].transform.position.x);
                    if (direction == 1)
                    {

                        rb.velocity = new Vector2(-5, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(5, rb.velocity.y);
                    }
                }


                //transform.localScale = new Vector2(5, 5);
            }
        }

    }
    public void Reset()
    {
        lifes = 0;
        currentHealth = 100;
        Time.timeScale = 1f;
       /* PlayerPrefs.SetInt("CurrentHealth", 100);
        PlayerPrefs.SetInt("Lifes", 3);
        PlayerPrefs.SetInt("ArrowPlayerHas", 10);*/
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}


