using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public List<Flag> flags = new List<Flag>();

    public List<string> playerItems = new List<string>(3);

    void Awake()
    { 
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        } 
    } 
    public static Vector2 GetMostRecentCheckpoint()
    { 
        for (int i = instance.flags.Count - 1; i >= 0; i--)
        { 
            if (instance.flags[i].checkpointReached)
            {
                instance.RestorePlayerInventory();
                return instance.flags[i].gameObject.transform.position;
            }
        }
        return Vector2.zero;
    }

    public static void SetPlayerItems(string one, string two, string three)
    {
        instance.playerItems[0] = one;
        instance.playerItems[1] = two;
        instance.playerItems[2] = three;
    }

    public static string GetPlayerItem(int slot)
    {
        return instance.playerItems[slot];
    }
    public void RestorePlayerInventory()
    {
        var inven = GameObject.FindWithTag("Inventory").GetComponent<InventoryManager>();
        for (int i = 0; i < 3; i++)
        {
            inven.SetInventorySlotWeapon(GetPlayerItem(i), i);
        }
    }  
}
