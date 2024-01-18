using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    TextMeshProUGUI tmp;

    void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();

    }
    void FixedUpdate()
    {
        if (tmp.color.a > 0)
        {
            Color color = tmp.color;
            color.a -= 0.015f;
            tmp.color = color;
        }
    }
    public void SetOpaque()
    { 
        Color color = tmp.color;
        color.a =1f;
        tmp.color = color;
    }
}
