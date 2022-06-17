using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DotHover : MonoBehaviour
{
    public int level;
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
            GameObject.FindWithTag("TransitionCanvas").GetComponent<Transition>().StartTransition(level.ToString());

    }
}
