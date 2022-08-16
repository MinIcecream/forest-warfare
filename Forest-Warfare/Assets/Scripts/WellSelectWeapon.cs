using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WellSelectWeapon : MonoBehaviour
{
    [SerializeField]
    string selectedWeapon;
    public Vector2 well;
    public TextMeshProUGUI button;

    public GameObject panel;

    public void SelectWeapon(string w)
    {
        selectedWeapon = w;
        button.text = w;
    }
    public void SpawnWeapon()
    {
        if (selectedWeapon != "")
        {
            GetComponent<InstantiateInteractableWeapon>().Spawn(selectedWeapon,well);
        }
    }
    public void CloseWell()
    {
        panel.SetActive(false);
        button.text = "";
        selectedWeapon = "";
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<SwapWeapon>().enabled = true;
    }
    void OnEnable()
    { 
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<SwapWeapon>().enabled = false;
    }
}
