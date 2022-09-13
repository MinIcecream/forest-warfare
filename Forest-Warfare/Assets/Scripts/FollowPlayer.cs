using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindWithTag("Player")!=null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y+1, player.transform.position.z - 15);
        }    
    }
}
