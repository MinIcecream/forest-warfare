using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShader : MonoBehaviour
{
    public Material normal;

    public Material damage;

    public void Damage()
    {
        GetComponent<SpriteRenderer>().material = damage;
        StartCoroutine(damageCountdown());
    }


    IEnumerator damageCountdown(){
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().material = normal;
    }
}
