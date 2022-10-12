using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBounce : MonoBehaviour
{
    public Rigidbody2D player;
    public PlayerMovement playerScript;
    bool canBounce = true;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy" && !playerScript.grounded && canBounce)
        {
            canBounce = false;
            StartCoroutine(Cooldown());
            player.AddForce(new Vector2(0, 20),ForceMode2D.Impulse); 
        }
    }
    IEnumerator Cooldown() 
    {
        yield return new WaitForSeconds(0.3f);
        canBounce = true;
    }

}
