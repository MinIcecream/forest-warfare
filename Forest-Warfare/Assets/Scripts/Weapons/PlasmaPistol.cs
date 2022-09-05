using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaPistol : ProjectileWeapon
{   
    public float size = 0.1f; 
    public bool charging = false;

    GameObject newBullet;

    new void Update()
    {
        base.Update();

        if (Input.GetMouseButtonUp(0))
        {   
            Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            Vector2 objPos = player.transform.position;
             
            if (charging && newBullet)
            {   
                StartCoroutine(Delay());
                 
                ammoScript.Shoot(); 
                
                newBullet.GetComponent<PlasmaOrb>().UnFollow();
                newBullet.GetComponent<PlasmaOrb>().dir = (mousePos - objPos);
                 
            }
            charging = false;
            StopAudio();

            newBullet = null;
        }
    }

    protected override void Shoot()
    {
        if (!charging)
        {
            charging = true;

            canShoot = false;

            newBullet = Instantiate(bullet, spawnPt.position, Quaternion.identity);
            newBullet.GetComponent<PlasmaOrb>().Follow(spawnPt);

            PlayAudio();
        }
    }
   
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }
    void OnDisable()
    {
        base.OnDisable();
        if (newBullet&&charging)
        {
            Destroy(newBullet);
            AudioManager.Stop("PlasmaPistolCharge");
        }
        newBullet = null;
    }
    void OnEnable()
    {
        base.OnEnable();
        canShoot = true;
    }
}
