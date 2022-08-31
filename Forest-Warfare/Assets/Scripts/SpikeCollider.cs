using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollider : MonoBehaviour
{
    public bool active = true;
    public int damage;
    public List<GameObject> hitEnemies = new List<GameObject>();

    void OnTriggerStay2D(Collider2D coll)
    {
        if (active)
        {
            if (coll.gameObject.tag == "Enemy")
            {
                if (!hitEnemies.Contains(coll.gameObject))
                {
                    AudioManager.Play("MeleeHit");
                    coll.gameObject.GetComponent<EnemyHealth>().DealDamage(damage);
                    hitEnemies.Add(coll.gameObject);
                    StartCoroutine(Cooldown(coll.gameObject));
                } 
            }
            else if (coll.gameObject.tag == "Interactable Terrain")
            {
                coll.gameObject.GetComponent<TerrainTrigger>().trigger = true;
            }
            else if (coll.gameObject.tag == "Player")
            {
                if (!hitEnemies.Contains(coll.gameObject))
                {
                    hitEnemies.Add(coll.gameObject); 
                    coll.gameObject.GetComponent<PlayerHealth>().DealDamage(damage);
                    StartCoroutine(Cooldown(coll.gameObject));
                }
            }
        }
    }
    IEnumerator Cooldown(GameObject obj)
    {
        yield return new WaitForSeconds(1.5f);
        hitEnemies.Remove(obj);
    }
}
