using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<EnemyHealth>().DealDamage(20);

        }
        else if (coll.gameObject.tag == "Interactable Terrain")
        {
            coll.gameObject.GetComponent<TerrainTrigger>().trigger = true;
        }
    }
}
