using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRangeAttackMovement : MonoBehaviour
{


    private BoxCollider2D boxCollider2d;

    #region Public Variables;
    public GameObject playerObject;
    public int maxHealth = 100;
    public int currentHealth;
    public int numberOfDamgeTake;
    public HealthBar healthBar;
    public Animator animator;
    public LootSystem lootSystem;
    EnemyShield shield;

    public Transform leftLimit;
    public Transform rightLimit;

    /*
    public AudioSource arrowHitSound;
    public AudioSource DeathSound;*/
    #endregion

    #region Private Variables
    private Transform target;
    private float distance;
    int direction = 1;
    #endregion
    // public float nextAttackTime; // after every 2 sec
    // public float damage;

    /*private void Awake()
    {
      
    }*/
    private void Start()
    {
        numberOfDamgeTake = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerObject = GameObject.FindGameObjectWithTag("Player");
        target = playerObject.transform;
        animator = GetComponent<Animator>();
        lootSystem = GetComponent<LootSystem>();
        shield = GetComponent<EnemyShield>();

    }
    // Update is called once per frame
    void Update()
    {
        Flip();
        if (!InsideOfLimit())
        {
            SelectTarget();
        }
    }

   
    void Flip()
    {
        distance = Vector2.Distance(transform.position, target.position);
        //Debug.Log(transform.position + "!! " + target.position);
        //Debug.Log("Flip called" + distance);
        Vector3 rotation = transform.eulerAngles;
        rotation.x *= -1;
      /*  if ( transform.position.x == target.position.x )
        {
            Debug.Log("Zero rotaion");
            rotation.y = 0f;
           
        }
        else*/ 
        if ( transform.position.x > target.position.x)//&& direction == 1
        {
           // Debug.Log("180 rotaion");
            rotation.y = 180f;
            direction = 2;

        }
        else if ( transform.position.x < target.position.x)//&& direction == 2
        {
            //Debug.Log("flip");
            rotation.y = 0;
            direction = 1;
        }
        else
        {
            Debug.Log("None rotaion");
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0) // Player can only damage enemy if health is greater than zero. if not on need to damage it
        {
            if (numberOfDamgeTake > 3)
                StartCoroutine(SheildTimer());
            if (!shield.ActiveShield)
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
                // play hurt animation
                StartCoroutine(RangeAttackSkeletonHurtAnimation());
                if (currentHealth <= 0)
                {
                    StartCoroutine(Die());
                    lootSystem.Spawnner(transform);
                }
            }
            else
                numberOfDamgeTake += 1;

        }
            
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
    IEnumerator Die()
     {
        animator.SetBool("Hurt", false);
        // Die Animation

        animator.SetBool("Death", true);
        Debug.Log("Skeleton died!");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.deathSound);
        yield return new WaitForSeconds(1f);
        // Disable the player 
        Destroy(gameObject);
     }
    public IEnumerator RangeAttackSkeletonHurtAnimation()
    {
        // play hurt animation
        animator.SetBool("Hurt", true);
        SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.arrowHitSound);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Hurt", false);

    }
    void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);
        Vector3 rotation = transform.eulerAngles;
        //Debug.Log(distanceToLeft + " " + distanceToRight);
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
        /*
        Debug.Log(transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x);*/
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }
}
