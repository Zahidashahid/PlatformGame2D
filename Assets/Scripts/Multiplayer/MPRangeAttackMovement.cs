using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPRangeAttackMovement : MonoBehaviour
{
    private BoxCollider2D boxCollider2d;

    #region Public Variables;
    public List<Transform> target;
    public int maxHealth = 100;
    public int currentHealth;
    public int numberOfDamgeTake;
    public HealthBar healthBar;
    public Animator animator;
    public LootSystem lootSystem;
    public float stopDistance = 5;
    public float retreatDistance = 3;
    public Rigidbody2D rb;
    public int direction = 2;
    EnemyShield shield;

    #endregion

    #region Private Variables
    private float distance;
   
    #endregion
    
    private void Start()
    {
        numberOfDamgeTake = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //target = playerObject.transform;
        animator = GetComponent<Animator>();
        lootSystem = GetComponent<LootSystem>();
        shield = GetComponent<EnemyShield>();

    }
    void Update()
    {
        Flip();
        if (target.Count == 0)
            return;
        /*else
            MovingTowardsPlayers();*/
    }

    void MovingTowardsPlayers()
    {
       
        /*
            -----------if enemy near enough but not much near stop  moving----------
         */
         if ((Vector2.Distance(transform.position, target[0].position) < stopDistance && Vector2.Distance(transform.position, target[0].position) > retreatDistance) ||
                (Vector2.Distance(transform.position, target[1].position) < stopDistance && Vector2.Distance(transform.position, target[1].position) > retreatDistance))
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
        else if ((Vector2.Distance(transform.position, target[0].position) < retreatDistance) ||
                (Vector2.Distance(transform.position, target[1].position) < retreatDistance))
        {
            //Debug.Log(" enemy moving away from player if it is very near to player-");
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

            /*
             ----------- enemy moving towards player----------
         */

            animator.SetFloat("Speed", Mathf.Abs(40));
            //Debug.Log(" enemy moving towards player");
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
    }

    void Flip()
    {
        distance = Vector2.Distance(transform.position, target[0].position);
        //Debug.Log(transform.position + "!! " + target.position);
        //Debug.Log("Flip called" + distance);
        Vector3 rotation = transform.eulerAngles;
        rotation.x *= -1;
        if (transform.position.x > target[0].position.x)//&& direction == 1
        {
            // Debug.Log("180 rotaion");
            rotation.y = 180f;
            direction = 2;
        }
        else if (transform.position.x < target[0].position.x)//&& direction == 2
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
}
