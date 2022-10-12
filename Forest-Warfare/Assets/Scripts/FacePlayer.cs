using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    GameObject player;

    void Update()
    {
        player = GameObject.FindWithTag("Player");

        if (player)
        {
            if (transform.position.x - player.transform.position.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
        }
    }
}
