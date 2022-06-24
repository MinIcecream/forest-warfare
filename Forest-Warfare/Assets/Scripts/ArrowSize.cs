using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowSize : MonoBehaviour
{
    string sizeState = "small";

    void FixedUpdate()
    {
        //SIZE
        if (sizeState == "small")
        {
            transform.localScale = new Vector2(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f);
            if (transform.localScale.x <= 0.9f)
            {
                sizeState = "big";
            }
        }
        else
        {
            transform.localScale = new Vector2(transform.localScale.x + 0.005f, transform.localScale.y + 0.005f);
            if (transform.localScale.x >= 1.1f)
            {
                sizeState = "small";
            }
        }
    }
}
