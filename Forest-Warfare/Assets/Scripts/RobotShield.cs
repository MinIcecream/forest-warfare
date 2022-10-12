using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShield : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    { 
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = 1;

        GetComponent<SpriteRenderer>().color = color; 
    } 
    void Update()
    { 
        Color color = GetComponent<SpriteRenderer>().color; 

        if(color.a > 0)
        {
            color.a -= 1.5f * Time.deltaTime;
            GetComponent<SpriteRenderer>().color = color;
        } 
    }
}
