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
            PlayerPrefs.SetInt("pistol", 1); 
            transform.Find("Pistol Parent").gameObject.SetActive(true);
        }
        else if (weapon == "spear")
        {
            PlayerPrefs.SetInt("spear", 1);
            transform.Find("Spear Parent").gameObject.SetActive(true);
        }
        else if (weapon == "sword")
        {
            PlayerPrefs.SetInt("sword", 1);
            transform.Find("Sword Parent").gameObject.SetActive(true);
        }
        else if (weapon == "telekinesisGun")
        {
            PlayerPrefs.SetInt("telekinesisGun", 1);
            transform.Find("Telekinesis Gun Parent").gameObject.SetActive(true);
        }
        else if (weapon == "flamethrower")
        {
            PlayerPrefs.SetInt("flamethrower", 1);
            transform.Find("Flamethrower Parent").gameObject.SetActive(true);
        }
        else if (weapon == "grenadeLauncher")
        {
            PlayerPrefs.SetInt("grenadeLauncher", 1);
            transform.Find("Grenade Launcher Parent").gameObject.SetActive(true);
        }
        else if (weapon == "rocketLauncher")
        {
            PlayerPrefs.SetInt("rocketLauncher", 1);
            transform.Find("Rocket Launcher Parent").gameObject.SetActive(true);
        }
        else if (weapon == "ak47")
        {
            PlayerPrefs.SetInt("ak47", 1);
            transform.Find("Ak47 Parent").gameObject.SetActive(true);
        }
        else if (weapon == "minigun")
        {
            PlayerPrefs.SetInt("minigun", 1);
            transform.Find("Minigun Parent").gameObject.SetActive(true);
        }
        else if (weapon == "sniper")
        {
            PlayerPrefs.SetInt("sniper", 1);
            transform.Find("Sniper Parent").gameObject.SetActive(true);
        }
        else if (weapon == "shotgun")
        {
            PlayerPrefs.SetInt("shotgun", 1);
            transform.Find("Shotgun Parent").gameObject.SetActive(true);
        }
        else if (weapon == "plasmaPistol")
        {
            PlayerPrefs.SetInt("plasmaPistol", 1);
            transform.Find("Plasma Pistol Parent").gameObject.SetActive(true);
        }
        else if(weapon=="none")
        {

        }
    }
}
