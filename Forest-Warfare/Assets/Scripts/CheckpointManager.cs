using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckpointManager : MonoBehaviour
{ 
    public List<Flag> flags = new List<Flag>();

    public List<string> playerItems = new List<string>(3);

    public GameObject playerPrefab;
    public GameObject player;
    public Vector2 origin;

    public string levelName;

    public GameObject recentCheckpoint;

    public static CheckpointManager instance;
    /*
    [System.Serializable]
    public struct enemy
    {
        public Vector2 pos;
        public GameObject obj;
    } 
    public List<enemy> enemies = new List<enemy>(); */

    void Update()
    {
        if (SceneManager.GetActiveScene().name != levelName)
        {
            Destroy(gameObject); 
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        /*
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy newEnemy=new enemy();
            newEnemy.pos = e.transform.position;
            newEnemy.obj = e;
            enemies.Add(newEnemy);
        }*/
    }
    public GameObject GetMostRecentCheckpoint()
    { 
        for (int i = flags.Count - 1; i >= 0; i--)
        { 
            if (flags[i].checkpointReached)
            {
                RestorePlayerInventory();
                return flags[i].gameObject;
            }
        }
        return null;
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
    public static void LoadLastCheckpoint()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //spawn new enemies,
        //spawn new player

        /*
        foreach (enemy e in instance.enemies)
        { 
            if(e.obj!=null)
            {
                var newEnemy=Instantiate(Resources.Load<GameObject>("Enemies/" + e.obj.name), e.pos, Quaternion.identity);
                newEnemy.name = e.obj.name;
                Destroy(e.obj);
            }  
        }
        instance.enemies.Clear();

        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy newEnemy = new enemy();
            newEnemy.pos = e.transform.position;
            newEnemy.obj = e;
            instance.enemies.Add(newEnemy);
        }
        */
        instance.StartCoroutine(instance.LoadSceneDelay());
         
    }
    IEnumerator LoadSceneDelay()
    {
        yield return null;
        instance.player = GameObject.FindWithTag("Player");

        instance.recentCheckpoint = instance.GetMostRecentCheckpoint();

        if (instance.recentCheckpoint != null)
        {
            Vector2 checkPt = instance.recentCheckpoint.transform.position;
            instance.player.transform.position = new Vector2(checkPt.x, checkPt.y + 3);
            instance.recentCheckpoint.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            instance.player.transform.position = instance.origin; 
        }
    }
}
