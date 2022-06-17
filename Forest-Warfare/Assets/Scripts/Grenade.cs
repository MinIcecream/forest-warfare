using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Explode explode;
    float tickTime = 3f;

    void Update()
    {
        tickTime -= Time.deltaTime;

        if (tickTime <= 0)
        {
            timerEnd();
        }
    }
    void timerEnd()
    {
        explode.Explosion();
    }
}