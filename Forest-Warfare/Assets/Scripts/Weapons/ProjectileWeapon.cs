using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : BaseWeaponTemplate
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

    public bool isAuto;

    public virtual void Update()
    { 
        if (isAuto)
        { 
            if (Input.GetMouseButton(0) && ammoScript.canShoot == true && !PauseManager.IsPaused() && canShoot)
            {
                ContinuouslyFiring();
            }
            else
            {
                NotContinuouslyFiring();
            }
        }
        else
        { 
            if (Input.GetMouseButtonDown(0) && ammoScript.canShoot == true && !PauseManager.IsPaused() && canShoot)
            {
                Shoot();
            }
        } 
         
    }
    public virtual void ContinuouslyFiring() 
    {
    }
    public virtual void NotContinuouslyFiring()
    {
    } 
    protected virtual void Shoot()
    {
        PlayAudio();
        canShoot = false;
        StartCoroutine(Delay());
        SpawnProjectile();
    } 

    public void SpawnProjectile()
    {
        var newBullet = Instantiate(bullet, spawnPt.position, Quaternion.identity);
        Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        Vector2 objPos = player.transform.position;
        newBullet.GetComponent<Projectile>().Propel((mousePos - objPos).normalized);

        ammoScript.Shoot();
    } 
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }
    public virtual void OnDisable()
    {
        base.OnDisable();
        if (GameObject.FindWithTag("AudioManager"))
        { 
            StopAudio();
        } 
    }
    public virtual void OnEnable()
    { 
        base.OnEnable();
        GameObject.FindGameObjectWithTag("AmmoUI").GetComponent<AmmoCounterUI>().ShowUI();
        GameObject.FindGameObjectWithTag("ChargeUI").GetComponent<ChargeCounterUI>().HideUI();

        GetComponent<WeaponAmmo>().SetAmmoUI();
    }
}
