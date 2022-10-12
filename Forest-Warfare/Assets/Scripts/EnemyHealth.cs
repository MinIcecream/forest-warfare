using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health;

    public EnemyHealthBar healthBar;

    public int startHealth;

    public bool indicate = true;

    public bool invulnerable = false;

    public void SetInvulnerable()
    {
        invulnerable = true;
    }
    public void SetVulnerable()
    {
        invulnerable = false;
    }
    public void DisableIndicator()
    {
        indicate = false; 
    }

    public int getHealth()
    {
        return health;
    }
    void Start()
    {
        health = startHealth;
        if (healthBar)
        {
            healthBar.SetMaxHealth(health);
        }      
    }
    public void DealDamage(int damage)
    {
        if (invulnerable)
        {
            return;
        }
        if (indicate)
        {
            GetComponent<DamageShader>().Damage();
        } 
        health -= damage;
        healthBar.SetHealth(health);
    }

    public void GainHealth(int gain)
    {
        health += gain;
        healthBar.SetHealth(health);
    }
}
