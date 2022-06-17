﻿using UnityEngine;
using EZCameraShake;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 15f;
    private Vector2 jumpForce = new Vector2(0, 20);
    private Vector2 SlamForce = new Vector2(0, -25);
    private Vector2 dashForce = new Vector2(30, 0);
    private Vector3 movement;

    private float targetPos;

    public Rigidbody2D rb;

    //jumping vars
    public int jumpCounter = 2;
    public bool grounded = true;
    public float checkRadius;
    public LayerMask whatIsGround;

    public GameObject feet;
    public GameObject doubleJumpDust;
    public GameObject dashDust;
    public GameObject runAndJumpDust;

    public Animator anim;

    private float dashInputTimer = 0.5f;
    private bool startDashTimer = false;
    private string previousKey;

    float dashTime = 0.3f;

    bool walking = false;
    public FlipPlayer facingDir;

    public bool canMove = true;

    public GameObject slamColl;

    void Update()
    {
        if (grounded)
        {
            ResetJump();
        }
        if (canMove)
        {

            CaptureInput();
        } 
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(feet.transform.position, checkRadius, whatIsGround);
        if (walking)
        {
            transform.position += movement * Time.deltaTime * movementSpeed;
            walking = false;
        }
    }
    void CaptureInput()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        
        if (movement.x != 0)
        {
            RequestAction("walk");
        }

        if (Input.GetKeyDown("space"))
        {
            RequestAction("jump");
        }

        //Dashing shit
        if (Input.GetKeyDown("d"))
        {
            if (startDashTimer)
            {
                if (dashInputTimer >= 0 && previousKey == "d")
                {
                    RequestAction("dash");
                    ResetDashTimer();
                }
            }
            else
            {
                startDashTimer = true;
            }
            previousKey = "d";
        }

        if (Input.GetKeyDown("a"))
        {
            if (startDashTimer)
            {
                if (dashInputTimer >= 0 && previousKey == "a")
                {
                    RequestAction("dash");
                    ResetDashTimer();
                }
            }
            else
            {
                startDashTimer = true;
            }
            previousKey = "a";
        }

        if (startDashTimer)
        {
            dashInputTimer -= Time.deltaTime;
        }
        if (dashInputTimer <= 0)
        {
            ResetDashTimer();
        }


        float speed = Mathf.Abs(movement.x);
        anim.SetFloat("speed", speed);
    }

    void ResetDashTimer()
    {
        startDashTimer = false;
        dashInputTimer = 0.2f;
    }

    IEnumerator Countdown(float time)
    {
        float counter = time;
        while (counter > 0)
        {
            yield return new WaitForSeconds(0.1f);
            counter--;
        }
        rb.gravityScale = 4f;
    }

    void Dash()
    {
        StartCoroutine(Countdown(dashTime));
        rb.velocity = Vector3.zero;
        rb.gravityScale = 0f;
        if (previousKey == "a")
        {
            rb.AddForce(-dashForce, ForceMode2D.Impulse);
            var dust = Instantiate(dashDust, transform.position, Quaternion.identity);
            dust.transform.RotateAround(transform.position, transform.up, 180f);
        }
        else
        {
            rb.AddForce(dashForce, ForceMode2D.Impulse);
            Instantiate(dashDust, transform.position, Quaternion.identity);
        }
         
    }
    void Walk()
    {
        walking = true;
    }
    void Jump()
    {
        if (jumpCounter > 0)
        { 
            if (jumpCounter == 1)
            {
                Instantiate(doubleJumpDust, feet.transform.position, Quaternion.identity);
            }
            else if (jumpCounter == 2)
            {
                runAndJumpDust.GetComponent<ParticleSystem>().Play();
            }
            grounded = false;
            anim.SetBool("grounded", false);
            anim.SetTrigger("jump");
            rb.velocity = Vector3.zero;
            transform.position = new Vector2(transform.position.x, transform.position.y + .5f);
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }
        jumpCounter--;
    }
  
    public void RequestAction(string action)
    {
        if (action is "dash")
        {
            Dash();        }
        if (action is "jump")
        {
            Jump();
        }

        if (action is "walk")
        {
            Walk(); 
        }
    }
    public void ResetJump()
    {
        anim.SetBool("grounded", true);
        grounded = true;
        jumpCounter = 2;
    }

    public void disableMovement()
    {
        canMove = false;
    }
    public void enableMovement()
    {
        canMove = true;
    }
}