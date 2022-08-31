using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : ProjectileWeapon
{ 
    public PlayerLook rotate;

    bool shooting = false;

    void Update()
    {
        if (Input.GetMouseButton(0) && ammoScript.canShoot == true && !PauseManager.IsPaused())
        {
            if (!shooting)
            {
                PlayAudio();
                shooting = true;
                StartCoroutine(shoot());
            }
        }
        else
        {
            StopAudio();
            shooting = false;
        }
    } 
    IEnumerator shoot()
    {
        while (shooting)
        { 
            ammoScript.Shoot();
            rotate.Shake(-5,5);
            Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            Vector2 objPos = player.transform.position;

            var newBullet = Instantiate(bullet, spawnPt.position, Quaternion.identity);
            newBullet.GetComponent<BulletProjectile>().dir = (mousePos - objPos).normalized;
            yield return new WaitForSeconds(0.15f);
        }
    }
    void OnDisable()
    {
        if (GameObject.FindWithTag("AudioManager"))
        {
            AudioManager.Stop("Ak47");
        } 
    }
}
