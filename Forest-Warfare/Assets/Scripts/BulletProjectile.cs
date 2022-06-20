using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public bool piercing;

    public Vector3 dir;
    float speed = 30f;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (dir != null)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rb.velocity = dir*speed;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!piercing)
        {
            Destroy(gameObject);
        }
        else if(coll.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        } 
    }
}
