using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateInteractableWeapon : MonoBehaviour
{
    public GameObject interactableWeapon;

    public void Spawn(string weaponName,Vector2 pos)
    { 
        var spawnedWeapon = Instantiate(interactableWeapon, pos, Quaternion.identity);
        spawnedWeapon.GetComponent<InteractableWeapon>().SetSprite(weaponName);
        spawnedWeapon.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 4);
    }
}
