using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

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
            AudioManager.Play("Rock");
            range.SetActive(true);
            rb.gravityScale = 1;
            falling = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        if (coll.gameObject.tag == "Ground" && falling)
        {
            Invoke("Delay", 0.5f);

            AudioManager.Play("Rock");
            hitGround = true;
            range.SetActive(false);
            falling = false;
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .1f);
        }
    }
    void Delay()
    { 
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
