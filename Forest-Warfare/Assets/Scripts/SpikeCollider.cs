using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollider : MonoBehaviour
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
                coll.gameObject.GetComponent<EnemyHealth>().DealDamage(damage);

            }
            else if (coll.gameObject.tag == "Interactable Terrain")
            {
                coll.gameObject.GetComponent<TerrainTrigger>().trigger = true;
            }
            else if (coll.gameObject.tag == "Player")
            {
                coll.gameObject.GetComponent<PlayerHealth>().DealDamage(damage);
            }
        }
    }
}
