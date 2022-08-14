using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AmmoIcon : MonoBehaviour
{
    public GameObject counter;

    void Update()
    {
        TextMeshProUGUI tmp=counter.GetComponent<TextMeshProUGUI>();
        float newX=counter.GetComponent<RectTransform>().anchoredPosition.x-10-tmp.preferredWidth/2;
        GetComponent<RectTransform>().anchoredPosition=new Vector2(newX,GetComponent<RectTransform>().anchoredPosition.y);
    }
}
