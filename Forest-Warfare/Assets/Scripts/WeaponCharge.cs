using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCharge : MonoBehaviour
{
    public float rechargeRate, useRate,rechargeDelay;

    public int currentCharge;

    Coroutine lastRoutine = null;

    public bool canShoot;

    public bool customCondition = true;

    bool recharging;

    ChargeCounterUI chargeUI;

    void Awake()
    {
        currentCharge = 100;
    }
    void OnEnable()
    {
        GameObject.FindWithTag("AmmoUI").GetComponent<AmmoCounterUI>().HideUI();
        chargeUI = GameObject.FindWithTag("ChargeUI").GetComponent<ChargeCounterUI>();
        chargeUI.ShowUI(); 
        
        if(recharging)
        {
            StartCoroutine(Recharge());
        }

        chargeUI.SetCharge(currentCharge);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && customCondition)
        {
            if(lastRoutine != null)
            {
                StopCoroutine(lastRoutine);
            }
             
            lastRoutine = StartCoroutine(UseCharge());  
        }
        if (Input.GetMouseButtonUp(0) && !recharging)
        {
            if (lastRoutine != null)
            {
                StopCoroutine(lastRoutine);
            }
            lastRoutine = StartCoroutine(Recharge());
        }

        if (currentCharge > 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
     
        chargeUI.SetCharge(currentCharge);
    }

    IEnumerator UseCharge()
    {
        recharging = false;
        while (true)
        {
            yield return new WaitForSeconds(useRate);
            if(currentCharge > 0)
            {
                currentCharge--;
            }
        }
    }
    IEnumerator Recharge()
    {
        recharging = true;
        yield return new WaitForSeconds(rechargeDelay);

        while (currentCharge < 100)
        {
            yield return new WaitForSeconds(rechargeRate);
            currentCharge++;
        }
    }
}