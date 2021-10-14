using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonProjectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask enemy;
    public Transform arrowTransform;
    PlayerMovement playerMovement; // Refer to script
    public SpriteRenderer spriteRenderer;
     GameObject playerObject;
     GameObject skeletonObject;
    public AudioSource arrowHitSound;
    Vector2 velocity;
    Vector3 newDirection;
    Vector3 targetDirection;
    public float offset;
    void Awake()
    {
        playerMovement = GameObject.Find("Player_Goblin").GetComponent<PlayerMovement>();
        playerObject = GameObject.Find("Player_Goblin");
        skeletonObject = GameObject.Find("Range Attack Skeleton");
       // velocity = new Vector3(speed * Time.deltaTime, 0, 0);

    }
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        Debug.Log(""+playerObject.transform.position.x +"< "+skeletonObject.transform.position.x);
        distance = Vector2.Distance(transform.position, playerObject.transform.position);
        /* targetDirection = playerObject.transform.position - transform.position;
         newDirection = Vector3.RotateTowards(transform.forward, targetDirection, speed * Time.deltaTime, 0.0f);
        */
        if (playerObject.transform.position.x < skeletonObject.transform.position.x )
        {
            Debug.Log("Inflip left");
           spriteRenderer.flipX = true;
           velocity = (Vector3.left * speed * Time.deltaTime );
        }
        else
        {
            Debug.Log("Inflip right");
            spriteRenderer.flipX = false;
            velocity = (Vector3.right * speed * Time.deltaTime);
        }
    }
    void Update()
    {
       // transform.rotation = Quaternion.LookRotation(newDirection);
        transform.Translate(velocity);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, enemy);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                arrowHitSound.Play();
                Debug.Log("Arrow hit Player");
                hitInfo.collider.GetComponent<PlayerMovement>().TakeDemage(30);
            }
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
