using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string name;
    public string rarity;
    public string displayName;
    public string description;

    public Weapon(string name, string rarity,string displayName,string description)
    {
        this.displayName = displayName;
        this.name = name;
        this.rarity = rarity;
        this.description = description;
    }
}
