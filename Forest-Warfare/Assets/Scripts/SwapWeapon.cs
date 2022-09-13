using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    string weaponCheck = "";
    string weapon;

    public InventoryManager inventoryManager;

    public BaseWeaponTemplate pistol, spear, bonecrusher, telekinesisGun, flamethrower, grenadeLauncher, rocketLauncher, minigun, ak47, sniper, shotgun, plasmaPistol, masterBlade;
    List<BaseWeaponTemplate> weapons = new List<BaseWeaponTemplate>();

    void Awake()
    {
        weapons.Add(pistol);
        weapons.Add(spear);
        weapons.Add(bonecrusher);
        weapons.Add(telekinesisGun);
        weapons.Add(flamethrower);
        weapons.Add(grenadeLauncher);
        weapons.Add(rocketLauncher);
        weapons.Add(minigun);
        weapons.Add(ak47);
        weapons.Add(sniper);
        weapons.Add(shotgun);
        weapons.Add(plasmaPistol);
        weapons.Add(masterBlade);

        inventoryManager = GameObject.FindWithTag("Inventory").GetComponent<InventoryManager>();
    }
    public string getWeapon()
    {
        return weapon;
    }
    void Update()
    {
        weapon = inventoryManager.GetEquippedWeapon();
        if (weaponCheck != weapon)
        {
            weaponCheck = weapon;
            UpdateWeapon();
        }
    }

    void UpdateWeapon()
    {
        foreach (BaseWeaponTemplate w in weapons)
        {
            w.enabled = false;
        }
        transform.Find("Feet").gameObject.SetActive(true);

        if (weapon == "pistol")
        {
            if (PlayerPrefs.GetInt("pistol", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Pistol");
                PlayerPrefs.SetInt("pistol", 1);
            }
            pistol.enabled = true;
        }
        else if (weapon == "spear")
        {
            if (PlayerPrefs.GetInt("spear", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Spear");

                PlayerPrefs.SetInt("spear", 1);
            } 
            spear.enabled = true;
        }
        else if (weapon == "bonecrusher")
        { 
            if (PlayerPrefs.GetInt("bonecrusher", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Bonecrusher");
                PlayerPrefs.SetInt("bonecrusher", 1);
            } 
            bonecrusher.enabled = true;
        }
        else if (weapon == "telekinesisGun")
        {
            if (PlayerPrefs.GetInt("telekinesisGun", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Telekinesis Gun");
                PlayerPrefs.SetInt("telekinesisGun", 1);
            }
            PlayerPrefs.SetInt("telekinesisGun", 1);
            telekinesisGun.enabled = true;
        }
        else if (weapon == "flamethrower")
        {
            if (PlayerPrefs.GetInt("flamethrower", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Flamethrower");
                PlayerPrefs.SetInt("flamethrower", 1);
            }
            PlayerPrefs.SetInt("flamethrower", 1);
            flamethrower.enabled = true;
        }
        else if (weapon == "grenadeLauncher")
        {
            if (PlayerPrefs.GetInt("grenadeLauncher", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Grenade Launcher");
                PlayerPrefs.SetInt("grenadeLauncher", 1);
            }
            PlayerPrefs.SetInt("grenadeLauncher", 1);
            grenadeLauncher.enabled = true;
        }
        else if (weapon == "rocketLauncher")
        {
            if (PlayerPrefs.GetInt("rocketLauncher", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Rocket Launcher");
                PlayerPrefs.SetInt("rocketLauncher", 1);
            }
             
            rocketLauncher.enabled = true;
        }
        else if (weapon == "ak47")
        {
            if (PlayerPrefs.GetInt("ak47", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Ak-47");
                PlayerPrefs.SetInt("ak47", 1);
            }
             
            ak47.enabled = true;
        }
        else if (weapon == "minigun")
        {
            if (PlayerPrefs.GetInt("minigun", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Minigun");
                PlayerPrefs.SetInt("minigun", 1);
            }
             
            minigun.enabled = true;
        }
        else if (weapon == "sniper")
        {
            if (PlayerPrefs.GetInt("sniper", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Sniper");
                PlayerPrefs.SetInt("sniper", 1);
            }
             
            sniper.enabled = true;
        }
        else if (weapon == "shotgun")
        {
            if (PlayerPrefs.GetInt("shotgun", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Shotgun");

                PlayerPrefs.SetInt("shotgun", 1);
            } 
            shotgun.enabled = true;
        }
        else if (weapon == "plasmaPistol")
        {
            if (PlayerPrefs.GetInt("plasmaPistol", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Plasma Pistol");

                PlayerPrefs.SetInt("plasmaPistol", 1);
            } 
            plasmaPistol.enabled = true;
        }
        else if(weapon=="masterBlade")
        {
            if (PlayerPrefs.GetInt("masterBlade", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Master Blade");

                PlayerPrefs.SetInt("masterBlade", 1);
            }
            masterBlade.enabled = true;
        }
    }
}
