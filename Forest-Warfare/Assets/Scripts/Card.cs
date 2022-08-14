using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    public string weaponName;

    public GameObject frontImage,frontText,backText,front,back; 

    public void SetCard(Weapon weapon)
    {
        weaponName = weapon.name;
        frontImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Weapons/" + weapon.name);
        frontImage.GetComponent<Image>().preserveAspect = true;

        StartCoroutine(SetSize());

        frontText.GetComponent<TextMeshProUGUI>().text = weapon.displayName;  

        frontText.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);

        if (backText)
        { 
            backText.GetComponent<TextMeshProUGUI>().text = weapon.description; 
        }
    } 
    public void FlipToBack()
    { 
        front.SetActive(false);
        back.SetActive(true);
    }
    public void FlipToFront()
    {
        front.SetActive(true);
        back.SetActive(false);
    }
    IEnumerator SetSize()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        float parentHeight = GetComponent<RectTransform>().rect.height * .3f;
        float parentWidth = GetComponent<RectTransform>().rect.width*.8f; 
        frontImage.GetComponent<RectTransform>().sizeDelta = new Vector2(parentWidth, parentHeight);
    }
    public void SelectWeapon()
    {
        transform.parent.GetComponent<WellSelectWeapon>().SelectWeapon(weaponName);
    }
}
