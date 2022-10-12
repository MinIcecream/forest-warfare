using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRing : MonoBehaviour
{
    void Update()
    {
        if (transform.localScale.x < 1.5f)
        {
            float scaleChangeFactor = 1f * Time.deltaTime;
            transform.localScale += new Vector3(scaleChangeFactor, scaleChangeFactor, scaleChangeFactor); 
        }
        else
        {
            Destroy(gameObject);
        }
    }  
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag=="Player Projectile"|| coll.gameObject.tag == "Enemy Projectile")
        {
            Destroy(coll.gameObject);
        }
    }
}
