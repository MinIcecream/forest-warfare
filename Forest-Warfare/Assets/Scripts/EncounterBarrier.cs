using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterBarrier : MonoBehaviour
{
    public EncounterManager manager;

    public void SetEndEncounterBarrier(EncounterManager man)
    {
        manager = man;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (manager)
        {
            if (col.gameObject.tag == "Player")
            {
                manager.EndEncounter();
            } 
        }
    }
}
