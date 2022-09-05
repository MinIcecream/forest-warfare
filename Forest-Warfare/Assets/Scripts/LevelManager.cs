using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{ 
    public GameObject playerPrefab;
    public GameObject player;
    public Vector2 origin;
    public List<string> playerItems = new List<string>();
    public List<GameObject> enemies = new List<GameObject>();
    public List<Vector2> positions = new List<Vector2>();
    void Awake()
    {  
        if (GameObject.FindWithTag("Player") == null)
        {
       //     player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        } 
    }
    // Start is called before the first frame update
    void Start()
    { 
        AudioManager.Play("Music"); 
        Vector2 checkPt = CheckpointManager.GetMostRecentCheckpoint(); 

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
