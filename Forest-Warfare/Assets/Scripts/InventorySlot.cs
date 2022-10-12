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
    public int slotNum;
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
    {/*
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
        }*/

        if (weapon != "")
        {
            weaponImage.SetActive(true);
            image.overrideSprite = Resources.Load<Sprite>("WeaponPortraits/" + weapon);
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
    public void SetPos(int activeSlot)
    {
        switch (activeSlot)
        {
            case 1:
                if (slotNum == 1)
                {
                    LeanTween.move(GetComponent<RectTransform>(), transform.parent.gameObject.GetComponent<InventoryManager>().pos1, .1f);
                    transform.SetSiblingIndex(2);
                }
                else if (slotNum == 2)
                {
                    LeanTween.move(GetComponent<RectTransform>(), transform.parent.gameObject.GetComponent<InventoryManager>().pos2, .1f);
                }
                else if (slotNum == 3)
                {
                    LeanTween.move(GetComponent<RectTransform>(), transform.parent.gameObject.GetComponent<InventoryManager>().pos3, .1f);
                }
                break;
            case 2:
                if (slotNum == 1)
                {
                    LeanTween.move(GetComponent<RectTransform>(), transform.parent.gameObject.GetComponent<InventoryManager>().pos3, .1f);
                }
                else if (slotNum == 2)
                {
                    transform.SetSiblingIndex(2);
                    LeanTween.move(GetComponent<RectTransform>(), transform.parent.gameObject.GetComponent<InventoryManager>().pos1, .1f);
                }
                else if (slotNum == 3)
                {
                    LeanTween.move(GetComponent<RectTransform>(), transform.parent.gameObject.GetComponent<InventoryManager>().pos2, .1f);
                }
                break;
            case 3:
                if (slotNum == 1)
                {
                    LeanTween.move(GetComponent<RectTransform>(), transform.parent.gameObject.GetComponent<InventoryManager>().pos2, .1f);
                }
                else if (slotNum == 2)
                {
                    LeanTween.move(GetComponent<RectTransform>(), transform.parent.gameObject.GetComponent<InventoryManager>().pos3, .1f);
                }
                else if (slotNum == 3)
                {
                    transform.SetSiblingIndex(2);
                    LeanTween.move(GetComponent<RectTransform>(), transform.parent.gameObject.GetComponent<InventoryManager>().pos1, .1f);
                }
                break;
        }
      
    }
}
