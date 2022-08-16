using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWeapon : MonoBehaviour
{
    Vector3 initialPos;
    Vector3 distance;
   // float speed = 0.03f;

    //bool goingUp = true;

    public GameObject popup;

    InventoryManager inventoryManager;

    public string weapon;
    public SpriteRenderer spriteRenderer;

    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        spriteRenderer.sprite = Resources.Load<Sprite>("Weapons/" + weapon);
        initialPos = transform.position;
        distance = new Vector3(initialPos.x, initialPos.y + 1.3f, initialPos.z);
    }
    
    void Update()
    {
        inventoryManager = GameObject.FindWithTag("Inventory").GetComponent<InventoryManager>();

        if (popup.activeInHierarchy == true && Input.GetKeyDown("e"))
        {
            if(inventoryManager.inventoryWeapons[inventoryManager.activeSlot - 1]==null)
            {
                SetSprite("");
            }
            else
            { 
                string currentWeapon = weapon;
                SetSprite(inventoryManager.inventoryWeapons[inventoryManager.activeSlot - 1]);
                inventoryManager.SwapItem(currentWeapon);
            } 
        }

        if (Vector2.Distance(player.transform.position, transform.position) < 3)
        { 
            popup.SetActive(true);
        }
        else
        { 
            popup.SetActive(false);
        }
    }/*
    void FixedUpdate()
    {
        if (goingUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, distance, speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPos, speed);
        }
    
        if (transform.position.y <= initialPos.y)
        {
            goingUp = true;
        }
        else if (transform.position.y >= distance.y)
        {
            goingUp = false;
        }
    }*/

    public void SetSprite(string newWeapon)
    {
        weapon = newWeapon;
        if (newWeapon == "")
        {
            Destroy(this.gameObject);
            spriteRenderer.sprite = null;
        }
        else
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Weapons/" + weapon);
        }  
    }
}
