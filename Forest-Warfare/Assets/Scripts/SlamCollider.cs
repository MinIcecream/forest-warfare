using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamCollider : MonoBehaviour
{
    private List<Collider2D> colliders = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().DealDamage(60);
        }
        else if (other.gameObject.tag == "Interactable Terrain")
        {
            other.gameObject.GetComponent<TerrainTrigger>().trigger = true;
        }
    }

}
