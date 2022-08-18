using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponPopup : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public Animator anim;
    bool crRunning = false;
    public List<string> queue = new List<string>();

    public void Popup(string weaponName)
    {
        queue.Add(weaponName); 
        if (!crRunning)
        {
            crRunning = true;

            StartCoroutine(PopupDuration(queue[0]));
        } 
    }

    IEnumerator PopupDuration(string weaponName)
    { 
        queue.Remove(weaponName);
        tmp.text = weaponName + " Unlocked";
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(4f);

        if (queue.Count > 0)
        {
            StartCoroutine(PopupDuration(queue[0]));
        }
        else
        {
            crRunning = false;
        }
    }
}
