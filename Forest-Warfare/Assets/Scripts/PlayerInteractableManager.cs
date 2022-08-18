using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractableManager : MonoBehaviour
{
    public List<PlayerInteractable> interactables = new List<PlayerInteractable>();

    public void AddToList(PlayerInteractable i)
    {
        interactables.Add(i);
    }
    public void RemoveFromList(PlayerInteractable i)
    {
        interactables.Remove(i);
    }
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            int highestPrio = 0;
            PlayerInteractable highestPrioInteractable = null;

            foreach(PlayerInteractable i in interactables)
            {
                if (i.priority > highestPrio)
                {
                    highestPrio = i.priority;
                    highestPrioInteractable = i;
                }
            }
        }

    }
}
