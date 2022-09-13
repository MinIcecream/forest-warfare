using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    public bool dead = false;
    bool invulnerable = false;
    public GameObject hurtCanvas;

    public int getHealth()
    {
        return health;
    }
    void Start()
    {
        health = 120;
        hurtCanvas = GameObject.FindWithTag("HurtCanvas");
        hurtCanvas.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void DealDamage(int damage)
    {
        if(!invulnerable)
        {
            hurtCanvas.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(DisableHurtCanvas());
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .1f);
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
                newWeapon.transform.SetParent(this.transform);
                Invoke("StartDeathTransition", 2f);

                List<string> playerInven = GameObject.FindWithTag("Inventory").GetComponent<InventoryManager>().inventoryWeapons;
                GameObject.FindWithTag("CheckpointManager").GetComponent<CheckpointManager>().SetPlayerItems(playerInven[0], playerInven[1], playerInven[2]);
                 
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
    IEnumerator DisableHurtCanvas()
    {
        yield return new WaitForSeconds(0.2f);
        hurtCanvas.transform.GetChild(0).gameObject.SetActive(false);
    }
}
