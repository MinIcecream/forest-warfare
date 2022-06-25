using UnityEngine;
using System.Collections;

public class Sign : MonoBehaviour
{
    public GameObject ui;
    void OnMouseEnter()
    {
        ui.SetActive(true);
    }
    void OnMouseExit()
    {
        ui.SetActive(false);
    }
}
