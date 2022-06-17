using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float despawnTime = 5f;

    void Update()
    {
        despawnTime -= Time.deltaTime;

        if (despawnTime <= 0)
        {
            timerEnd();
        }
    }
    void timerEnd()
    {
        Destroy(gameObject);
    }
}
