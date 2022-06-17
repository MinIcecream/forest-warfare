using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{
    public TerrainTrigger terrainTrigger;

    public Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(rb.velocity.magnitude > 0.5f)
        {
            terrainTrigger.trigger = true;
        }
    }
}
