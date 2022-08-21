using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    public List<Weapon> weaponList = new List<Weapon>();

    public static Weapon pistol = new Weapon("pistol", "common","Pistol","description here");


    public static Weapon spear = new Weapon("spear", "common","Spear", "description here");


    public static Weapon telekinesisGun = new Weapon("telekinesisGun", "common","Telekinesis Gun", "description here");


    public static Weapon grenadeLauncher = new Weapon("grenadeLauncher", "common","Grenade Launcher", "description here");


    public static Weapon rocketLauncher = new Weapon("rocketLauncher", "common","Rocket Launcher", "description here");


    public static Weapon sword = new Weapon("sword", "common","Sword", "description here");


    public static Weapon flamethrower = new Weapon("flamethrower", "common","Flamethrower", "description here");

    public static Weapon shotgun = new Weapon("shotgun", "common","Shotgun", "description here");

    public static Weapon ak47 = new Weapon("ak47", "common","Ak-47", "description here");

    public static Weapon sniper = new Weapon("sniper", "common","Sniper", "description here");

    
    public static Weapon minigun = new Weapon("minigun", "common","Minigun", "description here");

    public static Weapon plasmaPistol = new Weapon("plasmaPistol", "common", "Pistol", "description here");

    void Awake()
    {
        weaponList.Add(pistol);
        weaponList.Add(spear);
        weaponList.Add(telekinesisGun);
        weaponList.Add(grenadeLauncher);
        weaponList.Add(rocketLauncher);
        weaponList.Add(sword);
        weaponList.Add(flamethrower);
        weaponList.Add(shotgun);
        weaponList.Add(ak47);
        weaponList.Add(sniper);
        weaponList.Add(minigun);
        weaponList.Add(plasmaPistol);
    }
}
