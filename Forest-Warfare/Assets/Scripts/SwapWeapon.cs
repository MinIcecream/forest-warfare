using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    string weaponCheck = "";
    string weapon;

    public InventoryManager inventoryManager;
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
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.Find("Feet").gameObject.SetActive(true);

        if (weapon == "pistol")
        {
            if (PlayerPrefs.GetInt("pistol", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Pistol");
                PlayerPrefs.SetInt("pistol", 1);
            } 
            transform.Find("Pistol Parent").gameObject.SetActive(true);
        }
        else if (weapon == "spear")
        {
            if (PlayerPrefs.GetInt("spear", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Spear");

                PlayerPrefs.SetInt("spear", 1);
            } 
            transform.Find("Spear Parent").gameObject.SetActive(true);
        }
        else if (weapon == "bonecrusher")
        { 
            if (PlayerPrefs.GetInt("bonecrusher", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Bonecrusher");
                PlayerPrefs.SetInt("bonecrusher", 1);
            }
             
            transform.Find("Bonecrusher Parent").gameObject.SetActive(true);
        }
        else if (weapon == "telekinesisGun")
        {
            if (PlayerPrefs.GetInt("telekinesisGun", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Telekinesis Gun");
                PlayerPrefs.SetInt("telekinesisGun", 1);
            }
            PlayerPrefs.SetInt("telekinesisGun", 1);
            transform.Find("Telekinesis Gun Parent").gameObject.SetActive(true);
        }
        else if (weapon == "flamethrower")
        {
            if (PlayerPrefs.GetInt("flamethrower", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Flamethrower");
                PlayerPrefs.SetInt("flamethrower", 1);
            }
            PlayerPrefs.SetInt("flamethrower", 1);
            transform.Find("Flamethrower Parent").gameObject.SetActive(true);
        }
        else if (weapon == "grenadeLauncher")
        {
            if (PlayerPrefs.GetInt("grenadeLauncher", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Grenade Launcher");
                PlayerPrefs.SetInt("grenadeLauncher", 1);
            }
            PlayerPrefs.SetInt("grenadeLauncher", 1);
            transform.Find("Grenade Launcher Parent").gameObject.SetActive(true);
        }
        else if (weapon == "rocketLauncher")
        {
            if (PlayerPrefs.GetInt("rocketLauncher", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Rocket Launcher");
                PlayerPrefs.SetInt("rocketLauncher", 1);
            }
             
            transform.Find("Rocket Launcher Parent").gameObject.SetActive(true);
        }
        else if (weapon == "ak47")
        {
            if (PlayerPrefs.GetInt("ak47", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Ak-47");
                PlayerPrefs.SetInt("ak47", 1);
            }
             
            transform.Find("Ak47 Parent").gameObject.SetActive(true);
        }
        else if (weapon == "minigun")
        {
            if (PlayerPrefs.GetInt("minigun", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Minigun");
                PlayerPrefs.SetInt("minigun", 1);
            }
             
            transform.Find("Minigun Parent").gameObject.SetActive(true);
        }
        else if (weapon == "sniper")
        {
            if (PlayerPrefs.GetInt("sniper", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Sniper");
                PlayerPrefs.SetInt("sniper", 1);
            }
             
            transform.Find("Sniper Parent").gameObject.SetActive(true);
        }
        else if (weapon == "shotgun")
        {
            if (PlayerPrefs.GetInt("shotgun", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Shotgun");

                PlayerPrefs.SetInt("shotgun", 1);
            } 
            transform.Find("Shotgun Parent").gameObject.SetActive(true);
        }
        else if (weapon == "plasmaPistol")
        {
            if (PlayerPrefs.GetInt("plasmaPistol", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Plasma Pistol");

                PlayerPrefs.SetInt("plasmaPistol", 1);
            } 
            transform.Find("Plasma Pistol Parent").gameObject.SetActive(true);
        }
        else if(weapon=="masterBlade")
        {
            if (PlayerPrefs.GetInt("masterBlade", 0) == 0)
            {
                GameObject.FindWithTag("WeaponPopup").GetComponent<WeaponPopup>().Popup("Master Blade");

                PlayerPrefs.SetInt("masterBlade", 1);
            }
            transform.Find("Master Blade Parent").gameObject.SetActive(true);
        }
    }
}
