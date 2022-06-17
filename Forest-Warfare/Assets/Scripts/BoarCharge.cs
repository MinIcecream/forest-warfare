using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarCharge : MonoBehaviour
{
    public GameObject player;
    Vector3 dir;

    void FixedUpdate()
    {
        transform.position += dir * Time.deltaTime* 12;
    }
    public void Direction(Vector3 direction)
    {
        dir = direction;
    }
}