using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStamina : MonoBehaviour
{
    private int stamina;
    bool regen = false;

    public int getStamina()
    {
        return stamina;
    }
    void Start()
    {
        stamina = 100;
    }
    public void UseStamina(int s)
    {
        regen = false;
        stamina -= s; 
        StopAllCoroutines();
        StartCoroutine(RegenDelay());
    }

    public void GainStamina(int gain)
    {
        stamina += gain; 
    }

    IEnumerator RegenDelay()
    {
        yield return new WaitForSeconds(3f);
        regen = true;
        StartCoroutine(Regen()); 
    }
    IEnumerator Regen()
    {
        while (stamina < 100 && regen)
        {
            GainStamina(1);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
