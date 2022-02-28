using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float runSpeed;
    private float HorizontalMove = 0f;
    private bool FacingRight = true;
    public Animator animator;
    public float JumpForce;
    public bool isGrounded;
    public Transform GC;
    public float CheckRadius;
    public LayerMask WhatIsGround;
    private int extraJumps;
    public int extraJumpsValue;
    bool Jump = false;
    float sX, sY;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        sX = transform.position.x;
        sY = transform.position.y;
    }

    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
            animator.SetBool("IsJump", true);
        }

        if (isGrounded = true)
        {
            extraJumps = extraJumpsValue;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;
        }
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GC.position, CheckRadius, WhatIsGround);

        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;

        if (FacingRight == false && HorizontalMove > 0)
        {
            Flip();
        }
        else if (FacingRight == true && HorizontalMove < 0)
        {
            Flip();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DeadZone")
        {
            transform.position = new Vector3(sX, sY, transform.position.z);
        }
    }
}
