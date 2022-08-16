using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopulateWeaponCards : MonoBehaviour
{
    public bool isWell;

    WeaponList weaponList;
     
    void OnEnable()
    {
        Debug.Log("fodfdo");
        weaponList = GameObject.FindWithTag("WeaponList").GetComponent<WeaponList>();
        foreach (Card child in GetComponentsInChildren<Card>())
        {
            Destroy(child.gameObject);
        }
        foreach (Weapon weapon in weaponList.weaponList)
        {
            GameObject newCard;
            if (isWell)
            {
                newCard = Instantiate(Resources.Load<GameObject>("WellCard"), transform.position, Quaternion.identity);
            }
            else
            {
                newCard = Instantiate(Resources.Load<GameObject>("Card"), transform.position, Quaternion.identity);
            }
            newCard.transform.SetParent(gameObject.transform, false);
            newCard.GetComponent<Card>().SetCard(weapon);
        }
    }
}
