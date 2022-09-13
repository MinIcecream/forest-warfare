using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatter : MonoBehaviour
{
    void Awake()
    {
        foreach(Rigidbody2D child in GetComponentsInChildren<Rigidbody2D>())
        {
            child.AddForce(new Vector2(Random.Range(0, 301), Random.Range(0, 420)));
            child.gameObject.transform.rotation = (Quaternion.Euler(0, 0, Random.Range(0, 180)));
        }
    }
}
