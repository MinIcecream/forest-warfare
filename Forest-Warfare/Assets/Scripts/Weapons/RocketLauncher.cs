using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : ProjectileWeapon
{ 
    new void Update()
    {
        base.Update();
        if (ammoScript.currentAmmo==1)
        {
            transform.Find("Rocket Projectile").gameObject.SetActive(true);
        }
    }
    protected override void Shoot()
    {
        canShoot = false;
        StartCoroutine(Delay());
        AudioManager.Play("RocketLauncher");
        ammoScript.Shoot();

        transform.Find("Rocket Projectile").gameObject.SetActive(false);

        base.SpawnProjectile();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }
}
