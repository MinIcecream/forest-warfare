using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerHealth>().DealDamage(50);
        }
        else if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<EnemyHealth>().DealDamage(100);
        }
        else if (coll.gameObject.tag == "Interactable Terrain")
        {
            coll.gameObject.GetComponent<TerrainTrigger>().trigger = true;
        }
    }
}
