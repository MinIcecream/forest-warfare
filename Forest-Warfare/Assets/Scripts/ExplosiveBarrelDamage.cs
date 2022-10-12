using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelDamage : MonoBehaviour
{
    private List<Collider2D> TriggerList = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!TriggerList.Contains(coll))
        {
            TriggerList.Add(coll);
        }
    }

    void OnTriggerExit2D (Collider2D coll)
    {
        if (TriggerList.Contains(coll))
        {
            TriggerList.Remove(coll);
        }
    }

    public void Explode()
    {
        foreach (Collider2D coll in TriggerList)
        {
            if (coll)
            {
                GameObject other = coll.gameObject; 
                if (other.tag == "Player")
                {
                    other.GetComponent<PlayerHealth>().DealDamage(50);
                }
                else if (other.tag == "Enemy")
                {
                    if (other.GetComponent<EnemyHealth>() != null)
                    { 
                        other.GetComponent<EnemyHealth>().DealDamage(100);
                    } 
                }
                else if (other.tag == "Interactable Terrain")
                {
                    other.GetComponent<TerrainTrigger>().trigger = true;
                }

            }
        }
    }
}
