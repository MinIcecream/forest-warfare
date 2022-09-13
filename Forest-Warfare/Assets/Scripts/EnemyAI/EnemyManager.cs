using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;

    public virtual void Update()
    { 
        player = GameObject.FindWithTag("Player");
    }
}
