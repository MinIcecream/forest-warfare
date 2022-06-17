using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    public Rigidbody2D rb;
    public TerrainTrigger trigger;
    public GameObject range;
    bool hitGround = false;
    bool falling = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (trigger.trigger && !hitGround)
        {
            range.SetActive(true);
            rb.gravityScale = 1;
            falling = true;
        }

        if (coll.gameObject.tag == "Ground" && falling)
        {
            hitGround = true;
            range.SetActive(false);
            falling = false;
        }
    }
}
