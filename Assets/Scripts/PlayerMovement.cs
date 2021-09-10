using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private void Update()
    { 
        // Move Player back
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
        }
        // Move Player Forward
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
        }

        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(+5, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(+5, 0);
        }
    }
}
