using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public ParticleSystem flames;
    public float tickTime = 0f;

    private List<Collider2D> colliders = new List<Collider2D>();

    public WeaponCharge chargeScript;
    bool firing;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!colliders.Contains(other))
        {
            colliders.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        colliders.Remove(other);
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && chargeScript.canShoot == true && GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == false)
        {
            if (!firing)
            {
                AudioManager.Play("Flamethrower");
                GetComponent<BoxCollider2D>().enabled = true;
                ParticleSystem.EmissionModule em = flames.emission;
                em.enabled = true;
                firing = true;
            } 
        }
        else
        {
            firing = false;
            AudioManager.Stop("Flamethrower");
            GetComponent<BoxCollider2D>().enabled = false;
            ParticleSystem.EmissionModule em = flames.emission;
            em.enabled = false;
        }

        tickTime -= Time.deltaTime;

        if (tickTime <= 0 && Input.GetMouseButton(0))
        {
            timerEnd();
        }
    }
    void timerEnd()
    {
        DealDamage();
        tickTime = 0.3f;
    }

    void DealDamage()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            if(colliders[i] != null)
            {
                if(colliders[i].gameObject.tag == "Enemy")
                {
                    colliders[i].GetComponent<EnemyHealth>().DealDamage(20);
                }
                else if (colliders[i].gameObject.tag == "Interactable Terrain")
                {
                    colliders[i].GetComponent<TerrainTrigger>().trigger = true;
                }
            }
        }
    }
    void OnDisable()
    {
        if (GameObject.FindWithTag("AudioManager"))
        {
            AudioManager.Stop("Flamethrower");
        }
    }
}
