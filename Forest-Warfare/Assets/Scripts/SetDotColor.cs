using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDotColor : MonoBehaviour
{
    public SpriteRenderer[] dots;

    void Start()
    {
        for(int i = 1; i<= dots.Length; i++)
        {
            if (PlayerPrefs.GetInt("CompletedLevels", 0) >= i)
            {
                dots[i - 1].color = new Color(0f, 1f, 0f, 1f);
            }
            else if(PlayerPrefs.GetInt("CompletedLevels", 0) == i - 1)
            {

            }
            else
            {
                dots[i - 1].color = new Color(1f, 0f, 0f, 1f);
            }
        }
    }
}
