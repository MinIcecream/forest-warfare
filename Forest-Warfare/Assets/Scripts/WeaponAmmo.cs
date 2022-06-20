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

    void Awake()
    {
        currentAmmo = maxAmmo;
    }
    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("AmmoUI").GetComponent<AmmoCounterUI>().ShowUI();
        GameObject.FindGameObjectWithTag("ChargeUI").GetComponent<ChargeCounterUI>().HideUI();
        ammoUI = GameObject.FindWithTag("AmmoUI").GetComponent<AmmoCounterUI>();

        if (reloading)
        {
            StartCoroutine(Reload());
        }
        else
        {
            ammoUI.SetAmmo(currentAmmo, maxAmmo);
        }
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

        if (Input.GetKeyDown("r")&& currentAmmo!=maxAmmo)
        {
            reload=StartCoroutine(Reload());
        }
         
    }

    public void Shoot()
    {
        if (currentAmmo > 0 && !reloading)
        {
            currentAmmo--;
            ammoUI.SetAmmo(currentAmmo, maxAmmo);
        }
        else if (currentAmmo > 0 && reloading)
        {
            StopCoroutine(reload);
            reloading = false;
            currentAmmo--;
            ammoUI.SetAmmo(currentAmmo, maxAmmo);
        }

        else if (currentAmmo > 0 && !reloading)
        {
            currentAmmo--;
            ammoUI.SetAmmo(currentAmmo, maxAmmo);
        }
    }
    IEnumerator Reload()
    {
        ammoUI.SetReload();
        reloading = true;
        yield return new WaitForSeconds(reloadRate);
        currentAmmo = maxAmmo;
        reloading = false;
        ammoUI.SetAmmo(currentAmmo, maxAmmo);
    }
}
