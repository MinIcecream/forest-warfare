using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DotHover : MonoBehaviour
{
    public int level;
    protected enum state
    {
        Unlocked,
        Locked,
        Completed
    }
    state currentState;

    void Awake()
    {
        if (PlayerPrefs.GetInt("CompletedLevels", 5) >= level)
        {
            currentState = state.Completed;
            GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
        }
        else if (PlayerPrefs.GetInt("CompletedLevels", 5) == level - 1)
        {
            currentState = state.Unlocked;
        }
        else
        {
            currentState = state.Locked;
            GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        }
    }
     
    void OnMouseOver()
    {
        transform.localScale = new Vector2(1.3f, 1.3f);
    }
    void OnMouseExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }
    void OnMouseUp()
    {
        if (currentState != state.Locked)
        {
            GameObject.FindWithTag("TransitionCanvas").GetComponent<Transition>().StartTransition(level.ToString());
        } 
    }
}
