using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : BaseWeaponTemplate
{

    public override void OnEnable()
    {
        base.OnEnable();
        GameObject.FindGameObjectWithTag("AmmoUI").GetComponent<AmmoCounterUI>().HideUI();
        GameObject.FindGameObjectWithTag("ChargeUI").GetComponent<ChargeCounterUI>().HideUI();
    }
}
