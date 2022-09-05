using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeWeapon : BaseWeaponTemplate
{
    public WeaponCharge chargeScript;
    public bool firing;  

    public void Update()
    { 
        if (Input.GetMouseButton(0) && chargeScript.canShoot && !PauseManager.IsPaused())
        { 
            ContinuouslyFiring();
        }
        else
        {
            NotContinuouslyFiring();
        }
    }
    public virtual void ContinuouslyFiring()
    {

    }
    public virtual void NotContinuouslyFiring()
    {

    }
    public override void OnEnable()
    {
        base.OnEnable();
        GameObject.FindGameObjectWithTag("AmmoUI").GetComponent<AmmoCounterUI>().HideUI();
        GameObject.FindGameObjectWithTag("ChargeUI").GetComponent<ChargeCounterUI>().ShowUI();
    }
}
