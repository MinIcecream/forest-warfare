using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [HideInInspector]
    //whether player is actively using this weapon
    public bool active;
    [HideInInspector]
    //whether it can shoot
    public bool canShoot = true;

    //the bullet
    public GameObject bullet;
    //the ammo script
    public WeaponAmmo ammoScript;


    //the player
    public GameObject player;
    //the spawnpoint
    public Transform spawnPt;
    //the parent
    public GameObject parent;
     

    //how long to delay it
    public float fireDelay;

    //the name of the sound to play when fired
    public string audioName;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoScript.canShoot == true && !PauseManager.IsPaused() && canShoot)
        {  
            Shoot();
        }
    }
    protected virtual void Shoot()
    {
        PlayAudio();
        canShoot = false;
        StartCoroutine(Delay());

        var newBullet = Instantiate(bullet, spawnPt.position, Quaternion.identity);
        Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        Vector2 objPos = player.transform.position;
        newBullet.GetComponent<BulletProjectile>().dir = (mousePos - objPos).normalized;

        ammoScript.Shoot();
    } 
    public void PlayAudio()
    {
        AudioManager.Play(audioName);
    }
    public void StopAudio()
    { 
        AudioManager.Stop(audioName);
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }
}
