using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public Vector3 dir;
    float speed = 0.6f;

    void FixedUpdate()
    {
        if (dir != null)
        {
            transform.position += dir * speed;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(gameObject);
    }
}
