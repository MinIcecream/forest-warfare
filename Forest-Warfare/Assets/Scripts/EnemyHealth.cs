using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health;

    public EnemyHealthBar healthBar;

    public int getHealth()
    {
        return health;
    }
    void Start()
    {
        health = 100;
        if (healthBar)
        {
            healthBar.SetMaxHealth(health);
        }      
    }
    public void DealDamage(int damage)
    {
        GetComponent<DamageShader>().Damage();
        health -= damage;
        healthBar.SetHealth(health);
    }

    public void GainHealth(int gain)
    {
        health += gain;
        healthBar.SetHealth(health);
    }
}
