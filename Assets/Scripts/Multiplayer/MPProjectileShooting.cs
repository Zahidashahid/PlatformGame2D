using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPProjectileShooting : MonoBehaviour
{
    /*
     --------------- Projectile of arrow shoot by player 1 --------------------
     */
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask enemy;
    public Transform arrowTransform;
    MultiPlayer1 playerMovement; // Refer to script
    public SpriteRenderer spriteRenderer;
    Vector2 velocity;
    void Awake()
    {
        playerMovement = GameObject.Find("Player1").GetComponent<MultiPlayer1>();
    }
    void Start()
    {
        speed = 0.1f;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Invoke("DestroyProjectile", lifeTime);
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
            if (hitInfo.collider.name == "Skeleton" || hitInfo.collider.tag == "Skeleton")
            {
                    hitInfo.collider.GetComponent<MPMelleSkeletonMovement>().TakeDamage(10);
   
            }
            else if (hitInfo.collider.name == "Range Attack Skeleton" || hitInfo.collider.tag == "RangedAttackSkeleton")
            {
                    hitInfo.collider.GetComponent<MPRangeAttackMovement>().TakeDamage(10);          
            }
            else if (hitInfo.collider.name == "Player2" )
            {
                    hitInfo.collider.GetComponent<MultiPlayer2>().TakeDamage(10);          
            }
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
