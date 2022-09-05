using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public int magnitude;

    public virtual void Propel(Vector2 dir)
    {
        rb.AddForce(dir * magnitude, ForceMode2D.Impulse);
    }
}
