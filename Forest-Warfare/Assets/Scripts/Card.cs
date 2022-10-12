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

    public bool unlocked=false;

    public void SetCard(Weapon weapon)
    {
        StartCoroutine(Delay(weapon));
    } 
    public void FlipToBack()
    {
        if (PlayerPrefs.GetInt(weaponName, 0) == 0)
        {
            return;
        }
        front.SetActive(false);
        back.SetActive(true);
    }
    public void FlipToFront()
    {
        front.SetActive(true);
        back.SetActive(false);
    }
    void SetSize()
    { 
        float parentHeight = GetComponent<RectTransform>().rect.height;
        float parentWidth = GetComponent<RectTransform>().rect.width; 
        frontImage.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 150);
    }
    public void SelectWeapon()
    {
        transform.parent.GetComponent<WellSelectWeapon>().SelectWeapon(weaponName);
    }
    IEnumerator Delay(Weapon weapon)
    {
        yield return null;
        weaponName = weapon.name;
        frontImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("WeaponPortraits/" + weapon.name);
        frontImage.GetComponent<Image>().preserveAspect = true;

        float cardHeight = GetComponent<RectTransform>().rect.height;
        float cardWidth = GetComponent<RectTransform>().rect.width;

        float realHeight = cardWidth * 0.625f;

        float yPadding = (cardHeight - realHeight) / 2; 
        frontImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (18f/200*.6f)* cardHeight);
        frontText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, yPadding); 

        frontText.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);

        if (PlayerPrefs.GetInt(weaponName, 0) == 1)
        {
            unlocked = true;
        }
        if (!unlocked)
        {
            frontImage.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            frontText.GetComponent<TextMeshProUGUI>().text = "???";
        }
        else
        {
            frontText.GetComponent<TextMeshProUGUI>().text = weapon.displayName;
        }

        if (backText)
        {
            backText.GetComponent<TextMeshProUGUI>().text = weapon.description;
        }
        SetSize();
    }
}
