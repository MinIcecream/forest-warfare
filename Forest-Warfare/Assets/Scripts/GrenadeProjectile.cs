using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectile : MonoBehaviour
{
    public Rigidbody2D rb;

    public void Propel(Vector2 dir)
    {
        rb.AddForce(dir* 12, ForceMode2D.Impulse);
    }
}
