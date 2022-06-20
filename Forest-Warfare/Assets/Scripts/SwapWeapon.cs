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
            transform.Find("Pistol Parent").gameObject.SetActive(true);
        }
        else if (weapon == "spear")
        {
            transform.Find("Spear Parent").gameObject.SetActive(true);
        }
        else if (weapon == "sword")
        {
            transform.Find("Sword Parent").gameObject.SetActive(true);
        }
        else if (weapon == "telekinesisGun")
        {
            transform.Find("Telekinesis Gun Parent").gameObject.SetActive(true);
        }
        else if (weapon == "flamethrower")
        {
            transform.Find("Flamethrower Parent").gameObject.SetActive(true);
        }
        else if (weapon == "grenadeLauncher")
        {
            transform.Find("Grenade Launcher Parent").gameObject.SetActive(true);
        }
        else if (weapon == "rocketLauncher")
        {
            transform.Find("Rocket Launcher Parent").gameObject.SetActive(true);
        }
        else if (weapon == "ak47")
        {
            transform.Find("Ak47 Parent").gameObject.SetActive(true);
        }
        else if (weapon == "minigun")
        {
            transform.Find("Minigun Parent").gameObject.SetActive(true);
        }
        else if (weapon == "sniper")
        {
            transform.Find("Sniper Parent").gameObject.SetActive(true);
        }
        else if (weapon == "shotgun")
        {
            transform.Find("Shotgun Parent").gameObject.SetActive(true);
        }
        else if(weapon=="none")
        {

        }
    }
}
