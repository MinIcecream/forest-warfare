using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool hasHit = false;

    public Collider2D cirCollider;

    float despawnTime = 5f;

    public void Propel(Vector2 dir)
    {
        rb.AddForce(dir *80, ForceMode2D.Impulse);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void Update()
    {
        if (hasHit)
        {
            despawnTime -= Time.deltaTime;

            if (despawnTime <= 0)
            {
                timerEnd();
            }
        }
    }

    void FixedUpdate()
    {
        if (!hasHit)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            hasHit = true;
            cirCollider.enabled = false;
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0f;
        }
    }

    void timerEnd()
    {
        Destroy(gameObject);
    }
}
