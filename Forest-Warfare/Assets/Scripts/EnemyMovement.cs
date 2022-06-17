using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");

    }

    void Update()
    {
        if (player)
        {
            if (Vector2.Distance(player.transform.position, transform.position) > 7) 
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.01f);
            }
        }
    }
}
