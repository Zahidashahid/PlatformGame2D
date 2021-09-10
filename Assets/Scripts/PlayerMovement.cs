using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    void Awake()
    {
        player = new GameObject();
    }
    private void Update()
    { 
        // Move Player back
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        // Move Player Forward
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        // Jump Player 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
        /*if(Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(+5, 0);
        }*/
    }
}
