using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : ChargeWeapon
{
    public ParticleSystem flames;
    public float tickTime = 0f;
    public int damage = 20;
    private List<Collider2D> colliders = new List<Collider2D>();
     
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
        base.Update();

        tickTime -= Time.deltaTime;

        if (tickTime <= 0 && Input.GetMouseButton(0))
        {
            timerEnd();
        }
    }
    public override void ContinuouslyFiring()
    {
        if (!firing)
        {
            PlayAudio();
            GetComponent<BoxCollider2D>().enabled = true;
            ParticleSystem.EmissionModule em = flames.emission;
            em.enabled = true;
            firing = true;
        }
    }
    public override void NotContinuouslyFiring()
    { 
        StopAudio();
        GetComponent<BoxCollider2D>().enabled = false;
        ParticleSystem.EmissionModule em = flames.emission;
        em.enabled = false;
        firing = false;
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
                    colliders[i].GetComponent<EnemyHealth>().DealDamage(damage);
                }
                else if (colliders[i].gameObject.tag == "Interactable Terrain")
                {
                    colliders[i].GetComponent<TerrainTrigger>().trigger = true;
                }
            }
        }
    }
    public void OnDisable()
    {
        base.OnDisable();
        firing = false;
        AudioManager.Stop("Flamethrower");
        GetComponent<BoxCollider2D>().enabled = false;
        ParticleSystem.EmissionModule em = flames.emission;
        em.enabled = false;
        StopAudio();
    }
}
