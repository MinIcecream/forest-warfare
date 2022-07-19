using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShader : MonoBehaviour
{
    public Material normal;

    public Material damage;

    bool shouldDamage = false;

    public void Damage()
    {
        shouldDamage = true;
        StartCoroutine(damageCountdown());
    }

    void Update()
    {
        if (shouldDamage)
        {
            GetComponent<SpriteRenderer>().material = damage;
        }
        else
        {
            GetComponent<SpriteRenderer>().material = normal;
        }
    }

    IEnumerator damageCountdown(){
        yield return new WaitForSeconds(0.2f);
        shouldDamage=false;
    }
}
