using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public Rigidbody2D rb;

    [SerializeField] private float runSpeed = 40f;
    private float x_velocity = 0f;

    private bool jump = false;
    private bool crouch = false;
    public bool onWall = false;

    private float gravity;

    void Start()
    {
        gravity = rb.gravityScale;
    }

    private void FixedUpdate()
    {
        Move();
        jump = false;
    }

    private void Move()
    {
        controller.Move(x_velocity * Time.fixedDeltaTime, crouch, jump);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer.Equals(10))
        {
            onWall = true;
            Flip();
            anim.SetBool("Clinging", true);
            rb.gravityScale = 0;
            Debug.Log("touching wall");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(10))
        {
            onWall = false;
            Flip();
            anim.SetBool("Clinging", false);
            rb.gravityScale = gravity;
            Debug.Log("leaving wall");
        }
    }*/

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    void Update()
    {
        if(!PauseMenu.gameIsPaused)
        {
            /*if (anim.GetBool("Up") == false && anim.GetBool("Ducking") == false)
            {
                x_velocity = Input.GetAxisRaw("Horizontal") * runSpeed;
            }
            else
            {
                x_velocity = 0;
            }*/

            x_velocity = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (x_velocity != 0)
            {
                anim.SetBool("Running", true);
            }
            else
            {
                anim.SetBool("Running", false);
            }

            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("Up", true);
            }
            else
            {
                anim.SetBool("Up", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                crouch = true;
                anim.SetBool("Crouching", true);
            }
            else
            {
                crouch = false;
                anim.SetBool("Crouching", false);
            }

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                anim.SetTrigger("Jump");
            }

            /*if(Input.GetKey(KeyCode.C))
            {
                anim.SetBool("Clinging", true);
            }
            else
            {
                anim.SetBool("Clinging", false);
            }*/

            /*if(Input.GetKeyDown(KeyCode.H))
            {
                anim.SetTrigger("Hurt");
            }*/
        }
    }
}
