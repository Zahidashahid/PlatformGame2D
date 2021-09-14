using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    [SerializeField] private LayerMask m_WhatIsGround;
    public Rigidbody2D rb;

    int jumpCount = 0;
    bool jump ;
    bool crouch = false;
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
        if ((jumpCount < 2 ||  IsGrounded() == null) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            // IsGrounded();
            jumpCount++;
            rb.velocity = new Vector2(rb.velocity.x, 11f);
            animator.SetBool("IsJumping", true);
            Debug.Log(" jump count is " + jumpCount);
            
            if (jumpCount > 2)
            {
                jumpCount = 0;
            }


        }
       else
        {
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                animator.SetBool("IsJumping", true);
                jump = true;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("IsCrouching", true);
            crouch = true;
        }
        else
        {
            crouch = false;
        }
        /*if(Input.GetKey(KeyCode.S))
                {
                    rb.velocity = new Vector2(+5, 0);
                }*/
    }
     void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    public void OnLanding()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        Debug.Log("In OnLanding method");
        animator.SetBool("IsJumping", false);
        jumpCount = 0;
    }
    public void OnCrouching(bool isCrouching)
    {
        Debug.Log("In IsCrouching method");
        animator.SetBool("IsCrouching", isCrouching);

    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, m_WhatIsGround);
       // Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
   
}
