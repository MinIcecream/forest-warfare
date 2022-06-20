using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public string weapon="";
    private Image image;
    public GameObject weaponImage;
    private Image slotImage;

    public bool isSelected;

    void Start()
    {
        image = weaponImage.GetComponent<Image>();
        slotImage = GetComponent<Image>();
    }
    public string GetWeaponName()
    {
        if (weapon!="")
        {
            return weapon;
        }
        return "none";
    }
    void Update()
    {
        if (isSelected)
        {
            Color color = slotImage.color;
            color.a = 0.8f;
            slotImage.color = color;
        }
        else
        {
            Color color = slotImage.color;
            color.a = 0.2f;
            slotImage.color = color;
        }

        if (weapon != "")
        {
            weaponImage.SetActive(true);
            image.overrideSprite = Resources.Load<Sprite>("Weapons/" + weapon);
            image.preserveAspect = true;
        }
        else
        {
            weaponImage.SetActive(false);
        }
    }
    public void Select()
    {
        isSelected = true;
    }

    public void SetWeapon(string newWeapon)
    {
        weapon = newWeapon;
    }
    public void UnSelect()
    {
        isSelected = false;
    }
}
