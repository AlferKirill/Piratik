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
    public bool isGround;
    public Transform GC;
    public float CheckRadius;
    public LayerMask WhatIsGround;
    [Range(-5f, 5f)] public float checkGroundOffSetY = -1.8f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;
    bool Jump = false;
    float sX, sY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sX = transform.position.x;
        sY = transform.position.y;
    }

    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);           
        }

        if (isGround == false)
        {
            animator.SetBool("IsJump", true);
        }
        else
        {
            animator.SetBool("IsJump", false);
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
        isGround = Physics2D.OverlapCircle(GC.position, CheckRadius, WhatIsGround);

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
