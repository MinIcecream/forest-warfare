using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackFactor;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce((coll.gameObject.transform.position- transform.position).normalized * knockbackFactor);
        }
        else if (coll.gameObject.tag == "Interactable Terrain")
        {
            coll.gameObject.GetComponent<TerrainTrigger>().trigger = true;
        }
    }
}
