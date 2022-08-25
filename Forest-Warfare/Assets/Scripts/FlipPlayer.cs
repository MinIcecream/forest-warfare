using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour
{

    public SpriteRenderer sprite;
    public string facingDir = "left";
    public GameObject runAndJumpDust;
    private Vector3 movement;
    void Flip()
    {
        runAndJumpDust.GetComponent<ParticleSystem>().Play();

        if (movement.x <= 0)
        {
            sprite.flipX = true;
            facingDir = "left";
        }
        else
        {
            sprite.flipX = false;
            facingDir = "right";
        }
    }
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        if (facingDir == "right" && movement.x < 0)
        {
            Flip();

        }
        else if (facingDir == "left" && movement.x > 0)
        {
            Flip();
        }
    }

    public void FlipRight()
    { 
        sprite.flipX = false;
        facingDir = "right";
    }
    public void FlipLeft()
    { 
        sprite.flipX = true;
        facingDir = "left";
    }
}
