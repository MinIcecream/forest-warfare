using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : ProjectileWeapon
{  
    public PlayerLook rotate;

    public bool shooting = false;

    public float startDelay;

    public override void ContinuouslyFiring()
    { 
        if (!shooting)
        {
            PlayAudio();
            shooting = true;
            StartCoroutine(shoot());
        }
    }
    public override void NotContinuouslyFiring()
    { 
        StopAudio();
        shooting = false;
    }

    IEnumerator shoot()
    {
        while (shooting)
        { 
            rotate.Shake(-5,5);

            SpawnProjectile();

            if (startDelay > fireDelay)
            {
                startDelay -= 0.01f;
            }
            yield return new WaitForSeconds(startDelay);
        }
    } 
}
