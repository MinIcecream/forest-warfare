using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    void FixedUpdate()
    { 
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the Player
        GameObject player = GameObject.FindWithTag("Player");
        Vector2 playerPosition = (Vector2)Camera.main.WorldToViewportPoint(player.transform.position);
         
        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, playerPosition); 
        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
     
} 
