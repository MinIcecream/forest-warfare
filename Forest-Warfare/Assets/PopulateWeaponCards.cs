using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopulateWeaponCards : MonoBehaviour
{
    WeaponList weaponList;

    void Start()
    { 
        weaponList = GameObject.FindWithTag("WeaponList").GetComponent<WeaponList>();
        foreach (Weapon weapon in weaponList.weaponList)
        {
            GameObject newCard = Instantiate(Resources.Load<GameObject>("Card"), transform.position, Quaternion.identity);
            newCard.transform.SetParent(gameObject.transform, false);
            newCard.GetComponent<Card>().SetCard(weapon);
        }
    }
}
