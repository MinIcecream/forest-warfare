﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public bool active = true;
    public int damage;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (active)
        { 
            if (coll.gameObject.tag == "Enemy")
            {
                AudioManager.Play("MeleeHit");
                if (coll.gameObject.GetComponent<EnemyHealth>() != null)
                { 
                    coll.gameObject.GetComponent<EnemyHealth>().DealDamage(damage);
                } 
            }
            else if(coll.gameObject.tag == "Terrain")
            { 
                AudioManager.Play("MeleeHit");
            }
            else if (coll.gameObject.tag == "Interactable Terrain")
            {
                coll.gameObject.GetComponent<TerrainTrigger>().trigger = true;
            }
        } 
    } 
}
