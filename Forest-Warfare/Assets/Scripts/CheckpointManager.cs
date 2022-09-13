using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{ 
    public List<Flag> flags = new List<Flag>();

    public List<string> playerItems = new List<string>(3);

    public GameObject playerPrefab;
    public GameObject player;
    public Vector2 origin;
    [System.Serializable]
    public struct enemy
    {
        public Vector2 pos;
        public GameObject obj;
    } 
    public List<enemy> enemies = new List<enemy>();

    void Awake()
    {
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy newEnemy=new enemy();
            newEnemy.pos = e.transform.position;
            newEnemy.obj = e;
            enemies.Add(newEnemy);
        }
    }
    public Vector2 GetMostRecentCheckpoint()
    { 
        for (int i = flags.Count - 1; i >= 0; i--)
        { 
            if (flags[i].checkpointReached)
            {
                RestorePlayerInventory();
                return flags[i].gameObject.transform.position;
            }
        }
        return Vector2.zero;
    }

    public void SetPlayerItems(string one, string two, string three)
    {
        playerItems[0] = one;
        playerItems[1] = two;
        playerItems[2] = three;
    }

    public string GetPlayerItem(int slot)
    {
        return playerItems[slot];
    }
    public void RestorePlayerInventory()
    {
        var inven = GameObject.FindWithTag("Inventory").GetComponent<InventoryManager>();
        for (int i = 0; i < 3; i++)
        {
            inven.SetInventorySlotWeapon(GetPlayerItem(i), i);
        }
    }  
    public void LoadLastCheckpoint()
    {
        //spawn new enemies,
        //spawn new player
        foreach(enemy e in enemies)
        { 
            if(e.obj!=null)
            {
                var newEnemy=Instantiate(Resources.Load<GameObject>("Enemies/" + e.obj.name), e.pos, Quaternion.identity);
                newEnemy.name = e.obj.name;
                Destroy(e.obj);
            }  
        }
        enemies.Clear();

        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy newEnemy = new enemy();
            newEnemy.pos = e.transform.position;
            newEnemy.obj = e;
            enemies.Add(newEnemy);
        }

        Destroy(player);
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        
        Vector2 checkPt = GetMostRecentCheckpoint();

        if (checkPt != Vector2.zero)
        {
            player.transform.position = new Vector2(checkPt.x, checkPt.y + 3);
        }
        else
        {
            player.transform.position = origin;
        }
    }
}
