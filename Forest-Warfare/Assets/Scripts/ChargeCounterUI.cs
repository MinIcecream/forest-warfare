using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeCounterUI : MonoBehaviour
{
    public Slider slider;
    public GameObject[] children;

    public void SetCharge(int charge)
    {
        slider.value = charge;
    }
    public void ShowUI()
    {
        foreach (GameObject child in children)
        {
            child.SetActive(true);
        }
    }
    public void HideUI()
    {
        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }
    }
}
