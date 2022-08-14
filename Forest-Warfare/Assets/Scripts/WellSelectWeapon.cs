using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellSelectWeapon : MonoBehaviour
{
    [SerializeField]
    string selectedWeapon;
    public Vector2 well;

    public void SelectWeapon(string w)
    {
        selectedWeapon = w;
    }
    public void SpawnWeapon()
    {
        if (selectedWeapon != "")
        {
            GetComponent<InstantiateInteractableWeapon>().Spawn(selectedWeapon,well);
        }
    }
}
