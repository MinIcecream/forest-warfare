using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public int damage = 20;

    bool canDamage=true;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" &&canDamage)
        { 
            canDamage = false;
            StartCoroutine(DamageCooldown());
            coll.gameObject.GetComponent<PlayerHealth>().DealDamage(damage);
        }
        else if (coll.gameObject.tag == "Interactable Terrain")
        {
            coll.gameObject.GetComponent<TerrainTrigger>().trigger = true;
        }
    }
    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        canDamage = true;
    }
}
