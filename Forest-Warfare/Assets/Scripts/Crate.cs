using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject destroyedCrate;
    public TerrainTrigger trigger;
    public string weaponType;
    public rarity weaponRarity; 

    public WeaponList weaponList;

    private List<Weapon> availableWeapons = new List<Weapon>();

    private Weapon weaponToSpawn;
    public InventoryManager inven;

    void Awake()
    {
        inven = GameObject.FindWithTag("Inventory").GetComponent<InventoryManager>();
        weaponList=GameObject.FindWithTag("WeaponList").GetComponent<WeaponList>();
    }

    public enum rarity
    {
        common,
        rare,
        unique
    }
    void Update()
    {
        if (trigger.trigger)
        {
            AudioManager.Play("Crate");
            SpawnWeapon();
            DestroyCrate();
        }
    }

    void DestroyCrate()
    {
        Instantiate(destroyedCrate, transform.position, Quaternion.identity);
        GetComponent<InstantiateInteractableWeapon>().Spawn(weaponToSpawn.name, transform.position); 
        Destroy(gameObject);
    }

    void SpawnWeapon()
    {
        switch (weaponRarity)
        {
            case rarity.common:

                foreach(Weapon weapon in weaponList.weaponList)
                {
                    if(weapon.rarity == "common")
                    {
                        availableWeapons.Add(weapon);
                    }
                }
                break;
            case rarity.rare:
                foreach (Weapon weapon in weaponList.weaponList)
                {
                    if (weapon.rarity == "rare")
                    {
                        availableWeapons.Add(weapon);
                    }
                }
                break;
            case rarity.unique:
                foreach (Weapon weapon in weaponList.weaponList)
                {
                    if (weapon.rarity == "unique")
                    {
                        availableWeapons.Add(weapon);
                    }
                }
                break;
        }
        if(weaponType == "random")
        {
            int randomNum = Random.Range(1, availableWeapons.Count);
            weaponToSpawn = availableWeapons[randomNum];

            while (inven.inventoryWeapons.Contains(weaponToSpawn.name))
            {
                randomNum = Random.Range(1, availableWeapons.Count);
                weaponToSpawn = availableWeapons[randomNum];
            } 
        }
        else
        {
            weaponToSpawn = weaponList.weaponList.Find(r => r.name == weaponType);
        }
    }
}
