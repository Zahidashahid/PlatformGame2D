using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPProjectileShooting : MonoBehaviour
{
    /*
     --------------- Projectile of arrow shoot by player 1 and 2 --------------------
     */
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask enemy;
    public Transform arrowTransform;
    MultiPlayer2 playerMovement; // Refer to script
    public SpriteRenderer spriteRenderer;
    /*public AudioSource arrowHitSound;*/
    Vector2 velocity;
    void Awake()
    {
        playerMovement = GameObject.Find("Player2").GetComponent<MultiPlayer2>();
        // velocity = new Vector3(speed * Time.deltaTime, 0, 0);
    }
    void Start()
    {
        speed = 0.1f;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Invoke("DestroyProjectile", lifeTime);
        Debug.Log("playerMovement.PlayerMovingDirection() == 1 " + playerMovement.PlayerMovingDirection());
        if (playerMovement.PlayerMovingDirection() == 1)
        {
            spriteRenderer.flipX = true;
            velocity = (Vector3.left * speed);
        }
        else
        {
            spriteRenderer.flipX = false;
            velocity = (Vector3.right * speed);
        }
    }
    void Update()
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
                    hitInfo.collider.GetComponent<MPMelleSkeletonMovement>().TakeDamage(10);
   
            }
            if (hitInfo.collider.name == "Range Attack Skeleton" || hitInfo.collider.tag == "RangedAttackSkeleton")
            {
                    hitInfo.collider.GetComponent<SkeletonRangeAttackMovement>().TakeDamage(10);          
            }
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
