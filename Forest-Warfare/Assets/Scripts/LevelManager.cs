using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject Player;

    public List<string> playerItems = new List<string>();

    // Start is called before the first frame update
    void Start()
    { 
        
        AudioManager.Play("Music"); 
        Vector2 checkPt = CheckpointManager.GetMostRecentCheckpoint(); 

        if (checkPt != Vector2.zero)
        { 
            Player.transform.position = new Vector2(checkPt.x, checkPt.y + 3);
        } 

    }
}
