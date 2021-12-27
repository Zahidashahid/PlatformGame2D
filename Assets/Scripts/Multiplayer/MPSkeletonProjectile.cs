using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPSkeletonProjectile : MonoBehaviour
{
    /*
     * Range Attack by skeleton for Multiplayer game
     */
    public float speed;
    public float lifeTime;
    public LayerMask enemy;
    public Transform arrowTransform;
    public SpriteRenderer spriteRenderer;
    
    Vector2 velocity;
    Vector3 newDirection;
    Vector3 targetDirection;
    public float offset;
   
    void Start()
    {
        speed = 0.1f;
        Invoke("DestroyProjectile", lifeTime);
        velocity = (Vector3.right * speed);
    }
    void Update()
    {
        transform.Translate(velocity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player1")
        {
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.arrowHitSound);
            Debug.Log("Arrow hit Player 1");
            collision.GetComponent<MultiPlayer1>().TakeDamage(30);
            DestroyProjectile();
        }
        else if (collision.name == "Player2")
        {
            SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.arrowHitSound);
            Debug.Log("Arrow hit Player 2");
            collision.GetComponent<MultiPlayer2>().TakeDamage(30);
            DestroyProjectile();
        }

    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
