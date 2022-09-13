using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : ProjectileWeapon
{  
    public PlayerLook rotate;

    public bool shooting = false;

    public float startDelay;

    bool onCooldown = false;

    public override void ContinuouslyFiring()
    { 
        if (!shooting && !onCooldown)
        {
            onCooldown = true;
            StartCoroutine(shootCooldown());
            shooting = true;
            StartCoroutine(shoot());
        }
    }
    public override void NotContinuouslyFiring()
    {  
        shooting = false;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        shooting = false;
    }

    IEnumerator shoot()
    {
        float tempDelay = startDelay;
        float speed = 0.01f;

        while (shooting)
        {  
            rotate.Shake(-5,5);

            PlayAudio();
            SpawnProjectile();

            player.GetComponent<Rigidbody2D>().AddForce((player.transform.position-spawnPt.position).normalized * 120); 
             
            if (tempDelay > fireDelay)
            { 
                tempDelay -= speed;
                speed = Mathf.Pow(speed, 0.8f) * 0.6f;
            }
            yield return new WaitForSeconds(tempDelay);
        }
    }
    IEnumerator shootCooldown()
    {
        yield return new WaitForSeconds(0.4f);
        onCooldown = false;
    }
}
