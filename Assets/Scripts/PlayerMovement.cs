using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask m_WhatIsGround;
    public Rigidbody2D rb;
    
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    private BoxCollider2D boxCollider2d;
    private void Awake()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        // Move Player back
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        // Move Player Forward
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        // Jump Player 
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            IsGrounded();
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            animator.SetBool("IsJumping", true);
            
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {

            animator.SetBool("IsCrouching", true);
        }
        /*if(Input.GetKey(KeyCode.S))
                {
                    rb.velocity = new Vector2(+5, 0);
                }*/
    }
    public void IsJumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        animator.SetBool("IsJumping", false);

    }
    public void IsCrouching()
    {
        animator.SetBool("IsCrouching", false);
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, m_WhatIsGround);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
   
}
