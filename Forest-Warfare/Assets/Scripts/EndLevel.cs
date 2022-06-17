using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    bool completed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().disableMovement();
        completed = true;
        GameObject.FindWithTag("Player").GetComponent<FlipPlayer>().enabled = false;
        Invoke("StartTransition", 2f);
    }
    void FixedUpdate()
    {
        if (completed)
        {
            Vector3 dir = new Vector3(1f, 0f, 0f);
            GameObject.FindWithTag("Player").transform.position += dir* Time.deltaTime * 15f;
        } 
    }
    void StartTransition()
    {
        GameObject.FindWithTag("VictoryCanvas").GetComponent<DeathAndWinTransition>().StartTransition();
    }
}
