using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator anim;

    [SerializeField] private float jumpCooldown = 3f;
    private float currentJumpCooldown = 0f;

    [SerializeField] private float jumpForce = 1f;

    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck = null;

    [SerializeField] float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the Jumper is grounded.

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }

        if(m_Grounded)
        {
            anim.SetBool("Grounded", true);
        }
        else
        {
            anim.SetBool("Grounded", false);
        }

        if (currentJumpCooldown >= jumpCooldown)
        {
            Jump();
        }
        else
        {
            currentJumpCooldown += Time.deltaTime;
        }
    }

    void Jump()
    {
        currentJumpCooldown = 0f;
        //anim.SetTrigger("Jump");
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
