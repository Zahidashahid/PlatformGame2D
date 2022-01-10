using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    /*
     * Projectile of arrow shoot by player 
     */
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask enemy;
    public Transform arrowTransform;
    PlayerMovement playerMovement; // Refer to script
    public SpriteRenderer spriteRenderer;
    /*public AudioSource arrowHitSound;*/
    Vector2 velocity;
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
       // velocity = new Vector3(speed * Time.deltaTime, 0, 0);
    }
    void Start()
    {
        speed = 0.1f;
        Invoke("DestroyProjectile", lifeTime);
        if (playerMovement.PlayerMovingDirection() == 1)
        {
            spriteRenderer.flipX = true;
            velocity = (Vector3.left * speed );
        }
        else
        {
            spriteRenderer.flipX = false;
            velocity = (Vector3.right * speed );
        }
    }
    void FixedUpdate()
    {
        transform.Translate(velocity);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, enemy);
          
        if (hitInfo.collider != null)
        {
           // Debug.Log("Arrow hit Skeleton in scriptprojectile");
           // Debug.Log(hitInfo.collider.name);
           
            string difficultyLevel = PlayerPrefs.GetString("DifficultyLevel");
            //Debug.Log(difficultyLevel);
            if (hitInfo.collider.name == "Skeleton" || hitInfo.collider.tag == "Skeleton")
            {
                if (difficultyLevel == "Easy")
                {
                    hitInfo.collider.GetComponent<SkeletonEnemyMovement>().TakeDamage(40);
                }
                else if (difficultyLevel == "Medium")
                {
                    hitInfo.collider.GetComponent<SkeletonEnemyMovement>().TakeDamage(30);
                }
                else if (difficultyLevel == "Hard")
                {
                    hitInfo.collider.GetComponent<SkeletonEnemyMovement>().TakeDamage(10);
                }

            }
            if (hitInfo.collider.name == "Range Attack Skeleton" || hitInfo.collider.tag == "RangedAttackSkeleton")
            {
                
                if (difficultyLevel == "Easy")
                {
                    hitInfo.collider.GetComponent<SkeletonRangeAttackMovement>().TakeDamage(40);
                }
                else if (difficultyLevel == "Medium")
                {
                    hitInfo.collider.GetComponent<SkeletonRangeAttackMovement>().TakeDamage(30);
                }
                else if (difficultyLevel == "Hard")
                {
                    hitInfo.collider.GetComponent<SkeletonRangeAttackMovement>().TakeDamage(10);
                }
            }
            if (hitInfo.collider.tag == "Enemy")
            {
                GameObject hit = hitInfo.collider.gameObject;
                Destroy(hit);
            }
                DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    
}
