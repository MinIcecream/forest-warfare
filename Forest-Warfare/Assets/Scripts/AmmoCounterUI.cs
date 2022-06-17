using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCounterUI : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    public GameObject[] children;

    public void SetAmmo(int ammo, int maxAmmo)
    {
        tmp.text = ammo + "/" + maxAmmo;
    }
    public void SetReload()
    {
        tmp.text = "Reloading";
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
 