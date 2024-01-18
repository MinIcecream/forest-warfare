using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    public List<Weapon> weaponList = new List<Weapon>();

    public static Weapon pistol = new Weapon("pistol", "common","Pistol", "Ol’ reliable. Doesn’t do anything fancy, but can help you out in a pinch.");


    public static Weapon spear = new Weapon("spear", "common","Spear", "A long melee weapon. Flick your mouse to shoot out a spear that becomes a platform");


    public static Weapon telekinesisGun = new Weapon("telekinesisGun", "common","Telekinesis Gun", "Can be used to drag enemies and objects around.");


    public static Weapon grenadeLauncher = new Weapon("grenadeLauncher", "common","Grenade Launcher", "Launches grenades. What else did you expect?");


    public static Weapon rocketLauncher = new Weapon("rocketLauncher", "common","Rocket Launcher", "Shoots out rockets that go BOOM. Be careful not to hit yourself!");


    public static Weapon bonecrusher = new Weapon("bonecrusher", "common","Bonecrusher", "For heavy-duty foes. Try holding down your mouse button!");


    public static Weapon flamethrower = new Weapon("flamethrower", "common","Flamethrower", "Shoots out a big flame.");

    public static Weapon shotgun = new Weapon("shotgun", "common","Shotgun", "Shoots a spray of pellets. Best used up close and personal.");

    public static Weapon ak47 = new Weapon("ak47", "common","Ak-47", "An assault rifle that shoots out a fast stream of bullets.");

    public static Weapon sniper = new Weapon("sniper", "common","Sniper", "Each bullet packs a punch! Pierces, but does less damage to each subsequent enemy hit.");

    
    public static Weapon minigun = new Weapon("minigun", "common","Minigun", "A big gun that does big damage. Let ‘er rip!");

    public static Weapon plasmaPistol = new Weapon("plasmaPistol", "common", "Plasma Pistol", "Does puny damage unless charged up. Charging up all the time makes it turn into a gravity bomb.");

    public static Weapon masterBlade = new Weapon("masterBlade", "common", "Master Blade", "Click on enemies to dash through them.");

    void Awake()
    {
        weaponList.Add(pistol);
        weaponList.Add(spear);
        weaponList.Add(telekinesisGun);
        weaponList.Add(grenadeLauncher);
        weaponList.Add(rocketLauncher);
        weaponList.Add(bonecrusher);
        weaponList.Add(flamethrower);
        weaponList.Add(shotgun);
        weaponList.Add(ak47);
        weaponList.Add(sniper);
        weaponList.Add(minigun);
        weaponList.Add(plasmaPistol);
        weaponList.Add(masterBlade);
    }
}
