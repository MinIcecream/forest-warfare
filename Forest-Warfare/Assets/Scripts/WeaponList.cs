using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    public List<Weapon> weaponList = new List<Weapon>();

    public static Weapon pistol = new Weapon("pistol", "common");


    public static Weapon spear = new Weapon("spear", "common");


    public static Weapon telekinesisGun = new Weapon("telekinesisGun", "common");


    public static Weapon grenadeLauncher = new Weapon("grenadeLauncher", "common");


    public static Weapon rocketLauncher = new Weapon("rocketLauncher", "common");


    public static Weapon sword = new Weapon("sword", "common");


    public static Weapon flamethrower = new Weapon("flamethrower", "common");

    public static Weapon shotgun = new Weapon("shotgun", "common");
    public static Weapon ak47 = new Weapon("ak47", "common");
    public static Weapon sniper = new Weapon("sniper", "common");
    public static Weapon minigun = new Weapon("minigun", "common");

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
    }
}
