using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Weapon> inventoryWeapons = new List<Weapon>();

    public int weaponSlotAssign;

    public string[] addWeapons;

    public List<GameObject> weaponSlots = new List<GameObject>();

    public Dictionary<int, Weapon> weaponCatalogue = new Dictionary<int, Weapon>();

    public WeaponList weaponList;

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;

    public int activeSlot;

    public GameObject interactableWeapon;

    void Start()
    {
        foreach (string weaponName in addWeapons)
        {
            inventoryWeapons.Add(weaponList.weaponList.Find(r => r.name == weaponName));
        }
        weaponSlots.Add(slot1);
        weaponSlots.Add(slot2);
        weaponSlots.Add(slot3);
        weaponSlots.Add(slot4);
        weaponSlots.Add(slot5);
         
        updateInventory();
        slot1.GetComponent<InventorySlot>().Select();
        activeSlot = 1;
    }

    void Update()
    {
        if (GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == true||GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().dead==true)
        {
            return;
        }
        if (Input.GetKeyDown("1"))
        {
            UnselectAll();
            activeSlot = 1;
            slot1.GetComponent<InventorySlot>().Select();
        }
        if (Input.GetKeyDown("2"))
        {
            UnselectAll();
            activeSlot = 2;
            slot2.GetComponent<InventorySlot>().Select();
        }
        if (Input.GetKeyDown("3"))
        {
            UnselectAll();
            activeSlot = 3;
            slot3.GetComponent<InventorySlot>().Select();
        }
        if (Input.GetKeyDown("4"))
        {
            UnselectAll();
            activeSlot = 4;
            slot4.GetComponent<InventorySlot>().Select();
        }
        if (Input.GetKeyDown("5"))
        {
            UnselectAll();
            activeSlot = 5;
            slot5.GetComponent<InventorySlot>().Select();
        }

        var d = Input.GetAxis("Mouse ScrollWheel");

        if (d < 0f)
        {
            if (slot1.GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 2;
                slot2.GetComponent<InventorySlot>().Select();
            }
            else if (slot2.GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 3;
                slot3.GetComponent<InventorySlot>().Select();
            }
            else if (slot3.GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot =4;
                slot4.GetComponent<InventorySlot>().Select();
            }
            else if (slot4.GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 5;
                slot5.GetComponent<InventorySlot>().Select();
            }
            else if (slot5.GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 1;
                slot1.GetComponent<InventorySlot>().Select();
            }
        }
        if (d > 0f)
        {
            if (slot1.GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 5;
                slot5.GetComponent<InventorySlot>().Select();
            }
            else if (slot5.GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 4;
                slot4.GetComponent<InventorySlot>().Select();
            }
            else if (slot4.GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 3;
                slot3.GetComponent<InventorySlot>().Select();
            }
            else if (slot3.GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 2;
                slot2.GetComponent<InventorySlot>().Select();
            }
            else if (slot2.GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 1;
                slot1.GetComponent<InventorySlot>().Select();
            }
        }
    }
    void updateInventory()
    {
        weaponSlotAssign = 0;
        weaponCatalogue.Clear();

        foreach (GameObject slot in weaponSlots)
        {
            slot.GetComponent<InventorySlot>().UnSelect();
        }

        foreach (Weapon weapon in inventoryWeapons)
        {
            weaponSlotAssign++;
            weaponCatalogue.Add(weaponSlotAssign, weapon);

            switch (weaponSlotAssign)
            {
                case 1:
                    slot1.GetComponent<InventorySlot>().SetWeapon(weaponCatalogue[1]);
                    break;

                case 2:
                    slot2.GetComponent<InventorySlot>().SetWeapon(weaponCatalogue[2]);
                    break;

                case 3:
                    slot3.GetComponent<InventorySlot>().SetWeapon(weaponCatalogue[3]);
                    break;

                case 4:
                    slot4.GetComponent<InventorySlot>().SetWeapon(weaponCatalogue[4]);
                    break;
                case 5:
                    slot5.GetComponent<InventorySlot>().SetWeapon(weaponCatalogue[5]);
                    break;
            }
        }
    }

    public void SwapItem(string weapon)
    {
        if(activeSlot <= 1)
        {
            inventoryWeapons[0] = weaponList.weaponList.Find(r => r.name == weapon);
        }
        else
        {
            inventoryWeapons[activeSlot - 1] = weaponList.weaponList.Find(r => r.name == weapon);
        }
        
        updateInventory();
        weaponSlots[activeSlot - 1].GetComponent<InventorySlot>().Select();
    }

    public string GetEquippedWeapon()
    {
        switch (activeSlot)
        {
            case 1:
                return  slot1.GetComponent<InventorySlot>().weapon.name;
            case 2:
                return slot2.GetComponent<InventorySlot>().weapon.name;
            case 3:
                return slot3.GetComponent<InventorySlot>().weapon.name;
            case 4:
                return slot4.GetComponent<InventorySlot>().weapon.name;
            case 5:
                return slot5.GetComponent<InventorySlot>().weapon.name;
        }

        return "pistol";
    }
    void UnselectAll()
    {
        foreach (GameObject slot in weaponSlots)
        {
            slot.GetComponent<InventorySlot>().UnSelect();
        }
    }
}
