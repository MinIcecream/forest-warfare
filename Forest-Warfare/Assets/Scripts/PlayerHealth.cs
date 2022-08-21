using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    public bool dead = false;
    bool invulnerable = false;

    public int getHealth()
    {
        return health;
    }
    void Start()
    {
        health = 120;
    }
    public void DealDamage(int damage)
    {
        if(!invulnerable)
        { 
            GetComponent<DamageShader>().Damage();
            health -= damage; 
        } 
    }

    public void GainHealth(int gain)
    {
        if (!invulnerable)
        {
            health += gain;
        } 
    }

    void Update()
    {
        if (health <= 0)
        {
            if (!dead)
            {
                GetComponent<Animator>().SetTrigger("death");
                dead = true;
                GetComponent<PlayerMovement>().disableMovement();
                GetComponent<FlipPlayer>().enabled = false;
                GetComponent<SwapWeapon>().enabled = false;

                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }

                var newWeapon=Instantiate(Resources.Load<GameObject>("Weapons/LimpWeapon"), transform.position, Quaternion.identity);
                newWeapon.GetComponent<WeaponSprite>().SetSprite(GetComponent<SwapWeapon>().getWeapon());
                 
                Invoke("StartDeathTransition", 2f);
            } 
        }
    }

    void StartDeathTransition()
    {
        GameObject.FindWithTag("DeathCanvas").GetComponent<DeathAndWinTransition>().StartTransition();
    }
    public void SetInvulnerable(bool r)
    {
        invulnerable = r;
    }
}
