using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Animator anim;

    public Material normal;
    public Material shine;

    public Sprite raisedSprite;
    public Sprite normalSprite;

    public bool checkpointReached = false;

    public bool shineLight = false;
    public bool alreadyShined = false;

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
    void Update()
    {
        if (shineLight && !alreadyShined)
        {
            AudioManager.Play("CheckpointUnlock");
            GetComponent<SpriteRenderer>().material = shine;
            StartCoroutine(UnShine());
            alreadyShined = true;
        } 
    }
    IEnumerator UnShine()
    {
        yield return new WaitForSeconds(0.2f);

        GetComponent<SpriteRenderer>().material = normal;
    }
}
