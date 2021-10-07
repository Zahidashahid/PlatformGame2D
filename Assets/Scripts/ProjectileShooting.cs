using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask enemy;
    public Transform arrowTransform;
    PlayerMovement playerMovement; // Refer to script
    public GameObject player;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        playerMovement = GameObject.Find("Player_Goblin").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if(playerMovement.PlayerMovingDirection() == 1)
        {
            spriteRenderer.flipX = true;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
           
        else
        {
            spriteRenderer.flipX = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
          
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, enemy);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Skeleton"))
            {
                Debug.Log("Arrow hit Skeleton");
                hitInfo.collider.GetComponent<SkeletonEnemyMovement>().TakeDemage(40);
            }
            DestroyProjectile();
        }
        //arrowTransform.rotation = Quaternion.Euler(0f, 0f, 180);
      
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {*//*
            arrowTransform.rotation = Quaternion.Euler(0f, 0f, 180);*//*
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else*/
            
    }
    void DestroyProjectile()
    {
       // Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
