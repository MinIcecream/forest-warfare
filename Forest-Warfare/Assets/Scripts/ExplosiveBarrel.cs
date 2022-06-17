using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public Explode explode;
    public TerrainTrigger trigger;

    void Update()
    {
        if (trigger.trigger)
        {
            explode.Explosion();
        }
    }
}
