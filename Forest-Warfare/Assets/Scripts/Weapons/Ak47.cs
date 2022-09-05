using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : ProjectileWeapon
{ 
    public PlayerLook rotate;

    bool shooting = false;

    bool onCooldown = false;

    public override void ContinuouslyFiring()
    { 
        if (!shooting && !onCooldown)
        {
            onCooldown = true;
            StartCoroutine(shootCooldown());
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
            yield return new WaitForSeconds(0.15f);
        }
    } 

    IEnumerator shootCooldown()
    {
        yield return new WaitForSeconds(0.15f);
        onCooldown = false;
    }
}
