using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPPojectileShootingP2 : MonoBehaviour
{
    /*
     --------------- Projectile of arrow shoot by player  2 --------------------
     */
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask enemy;
    public Transform arrowTransform;
    MultiPlayer2 playerMovement; // Refer to script
    public SpriteRenderer spriteRenderer;
    Vector2 velocity;
    void Awake()
    {
        playerMovement = GameObject.Find("Player2").GetComponent<MultiPlayer2>();
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
            if (hitInfo.collider.name == "Skeleton" || hitInfo.collider.tag == "Skeleton")
            {
                hitInfo.collider.GetComponent<MPMelleSkeletonMovement>().TakeDamage(10);

            }
            else if (hitInfo.collider.name == "Range Attack Skeleton" || hitInfo.collider.tag == "RangedAttackSkeleton")
            {
                hitInfo.collider.GetComponent<MPRangeAttackMovement>().TakeDamage(10);
            }
            else if (hitInfo.collider.name == "Player1")
            {
                hitInfo.collider.GetComponent<MultiPlayer1>().TakeDamage(10);
            }
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
