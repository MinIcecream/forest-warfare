using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerHealth>().DealDamage(20);
        }
        else if (coll.gameObject.tag == "Interactable Terrain")
        {
            coll.gameObject.GetComponent<TerrainTrigger>().trigger = true;
        }
    }
}
