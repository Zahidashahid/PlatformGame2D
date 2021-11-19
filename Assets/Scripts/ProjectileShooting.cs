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
        playerMovement = GameObject.Find("Player_Goblin").GetComponent<PlayerMovement>();
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
    void Update()
    {
        transform.Translate(velocity);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, enemy);
          
        if (hitInfo.collider != null)
        {
            Debug.Log("Arrow hit Skeleton in scriptprojectile");
            if (hitInfo.collider.name == "Skeleton" || hitInfo.collider.tag == "Skeleton")
            {
                if (MainMenu.difficultyLevel == "easy")
                {
                    hitInfo.collider.GetComponent<SkeletonEnemyMovement>().TakeDemage(40);
                }
                else if (MainMenu.difficultyLevel == "medium")
                {
                    hitInfo.collider.GetComponent<SkeletonEnemyMovement>().TakeDemage(30);
                }
                else if (MainMenu.difficultyLevel == "hard")
                {
                    hitInfo.collider.GetComponent<SkeletonEnemyMovement>().TakeDemage(10);
                }

            }
            if (hitInfo.collider.name == "Range Attack Skeleton" || hitInfo.collider.tag == "RangedAttackSkeleton")
            {
                
                if (MainMenu.difficultyLevel == "easy")
                {
                    hitInfo.collider.GetComponent<SkeletonRangeAttackMovement>().TakeDemage(40);
                }
                else if (MainMenu.difficultyLevel == "medium")
                {
                    hitInfo.collider.GetComponent<SkeletonRangeAttackMovement>().TakeDemage(30);
                }
                else if (MainMenu.difficultyLevel == "hard")
                {
                    hitInfo.collider.GetComponent<SkeletonRangeAttackMovement>().TakeDemage(10);
                }
            }
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    
}
