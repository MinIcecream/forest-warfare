using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Animator anim;

    public Material normal;
    public Material shine;

    public Sprite raisedSprite;

    public bool checkpointReached = false;
     
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!checkpointReached)
        { 
            anim.SetTrigger("Raise");
              
            checkpointReached = true; 
        } 
    }  
    public void SetRaised()
    {
        GetComponent<SpriteRenderer>().sprite = raisedSprite; 
    }
}
