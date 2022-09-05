using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponAmmo : MonoBehaviour
{
    public int maxAmmo;

    public float reloadRate;

    public int currentAmmo;

    public bool reloading;

    public bool canShoot;

    AmmoCounterUI ammoUI;

    Coroutine reload;

    void Start()
    {
        currentAmmo = maxAmmo;
        ammoUI = GameObject.FindWithTag("AmmoUI").GetComponent<AmmoCounterUI>();

        SetAmmoUI();
    } 
    void Update()
    {
        if (currentAmmo <= 0 && reloading == false)
        {
            reload=StartCoroutine(Reload());
        } 

        else if(currentAmmo > 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }

        if (Input.GetKeyDown("r") && currentAmmo != maxAmmo)
        {
            reload=StartCoroutine(Reload());
        } 
    }

    public void Shoot()
    {
        if (currentAmmo > 0 && !reloading)
        {
            currentAmmo--;
            SetAmmoUI();
        }
        else if (currentAmmo > 0 && reloading)
        {
            StopCoroutine(reload);
            reloading = false;
            currentAmmo--;
            SetAmmoUI();
        }

        else if (currentAmmo > 0 && !reloading)
        {
            currentAmmo--;
            SetAmmoUI();
        }
    }
    IEnumerator Reload()
    {
        ammoUI.SetReload();
        reloading = true;

        yield return new WaitForSeconds(reloadRate);

        currentAmmo = maxAmmo;
        reloading = false;
        SetAmmoUI();
    }
    public void SetAmmoUI()
    {
        if (GetComponent<BaseWeaponTemplate>().enabled&&ammoUI!=null)
        { 
            ammoUI.SetAmmo(currentAmmo, maxAmmo);
        }
    }
}
