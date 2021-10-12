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
    Vector2 pos;
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
        pos = transform.position;
    }
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        Debug.Log(""+playerObject.transform.position.x +"< "+skeletonObject.transform.position.x);

         targetDirection = playerObject.transform.position - transform.position;
        
        newDirection = Vector3.RotateTowards(transform.forward, targetDirection, speed * Time.deltaTime, 0.01f);
        /*if (playerObject.transform.position.x < skeletonObject.transform.position.x )
        {
            spriteRenderer.flipX = true;
           //velocity = (Vector3.left * speed * Time.deltaTime );
        }
        else
        {
            spriteRenderer.flipX = false;
           // velocity = (Vector3.right * speed * Time.deltaTime);
        }*/
    }
    void Update()
    {
        //
        
       // transform.rotation = Quaternion.LookRotation(newDirection);
        transform.Translate(newDirection);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, enemy);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("Arrow hit Player");
                hitInfo.collider.GetComponent<PlayerMovement>().TakeDemage(10);

            }
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
