using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Vector2 pos1, pos2, pos3;
    public List<string> inventoryWeapons = new List<string>(3);

    public List<GameObject> weaponSlots = new List<GameObject>(3);

    public int activeSlot;

    public GameObject interactableWeapon;

    void Start()
    {
        updateInventory();

        weaponSlots[0].GetComponent<InventorySlot>().Select();
        activeSlot = 1;
    }

    void Update()
    {
        GetInput();
    }

    void updateInventory()
    {
        foreach (GameObject slot in weaponSlots)
        {
            slot.GetComponent<InventorySlot>().UnSelect();
        }
        for (int i= 0; i<weaponSlots.Count;i++)
        {
            weaponSlots[i].GetComponent<InventorySlot>().SetWeapon(inventoryWeapons[i]);
        }
    }

    public void SwapItem(string weapon)
    {
        if (activeSlot <= 1)
        {
            inventoryWeapons[0] = weapon;
        }
        else
        {
            inventoryWeapons[activeSlot - 1] = weapon;
        }
        
        updateInventory();
        weaponSlots[activeSlot - 1].GetComponent<InventorySlot>().Select();
    }
    public void SetInventorySlotWeapon(string weapon, int slot)
    {
        inventoryWeapons[slot] = weapon;
        updateInventory();
    }
    public string GetEquippedWeapon()
    {
        switch (activeSlot)
        {
            case 1:
                return weaponSlots[0].GetComponent<InventorySlot>().GetWeaponName();
            case 2:
                return weaponSlots[1].GetComponent<InventorySlot>().GetWeaponName();
            case 3:
                return weaponSlots[2].GetComponent<InventorySlot>().GetWeaponName();
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

    void GetInput()
    {
        if (GameObject.FindWithTag("Player") == null)
        {
            return;
        }
        if (GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == true || GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().dead == true)
        {
            return;
        }
        if (Input.GetKeyDown("1"))
        {
            UnselectAll();
            activeSlot = 1;
            weaponSlots[0].GetComponent<InventorySlot>().Select();
            RotateSlots();
        }
        if (Input.GetKeyDown("2"))
        {
            UnselectAll();
            activeSlot = 2;
            weaponSlots[1].GetComponent<InventorySlot>().Select();
            RotateSlots();
        }
        if (Input.GetKeyDown("3"))
        {
            UnselectAll();
            activeSlot = 3;
            weaponSlots[2].GetComponent<InventorySlot>().Select();
            RotateSlots();
        }

        var d = Input.GetAxis("Mouse ScrollWheel");

        if (d < 0f)
        { 
            if (weaponSlots[0].GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 2;
                weaponSlots[1].GetComponent<InventorySlot>().Select();
            }
            else if (weaponSlots[1].GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 3;
                weaponSlots[2].GetComponent<InventorySlot>().Select();
            }
            else if (weaponSlots[2].GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 1;
                weaponSlots[0].GetComponent<InventorySlot>().Select();
            }
            RotateSlots();
        }
        if (d > 0f)
        {
            if (weaponSlots[0].GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 3;
                weaponSlots[2].GetComponent<InventorySlot>().Select();
            }
            else if (weaponSlots[2].GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 2;
                weaponSlots[1].GetComponent<InventorySlot>().Select();
            }
            else if (weaponSlots[1].GetComponent<InventorySlot>().isSelected)
            {
                UnselectAll();
                activeSlot = 1;
                weaponSlots[0].GetComponent<InventorySlot>().Select();
            }
            RotateSlots();
        }
    }

    void RotateSlots()
    {
        foreach(GameObject slot in weaponSlots)
        {
            slot.GetComponent<InventorySlot>().SetPos(activeSlot);
        }
    }
}
