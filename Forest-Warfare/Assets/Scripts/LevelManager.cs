using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    public List<string> playerItems = new List<string>();
    public List<GameObject> enemies = new List<GameObject>();
    public List<Vector2> positions = new List<Vector2>();
 
    // Start is called before the first frame update
    void Start()
    { 
        AudioManager.Play("Music");
    }
    public static void SwitchToBossMusic()
    {
        AudioManager.SetVolume("Music", 0f);
        AudioManager.Play("BossMusic");
    }
    public static void SwitchToMusic()
    { 
        AudioManager.SetVolume("Music", 0.22f);
        AudioManager.Stop("BossMusic");
    }
}
