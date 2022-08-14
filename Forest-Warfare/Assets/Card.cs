using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    GameObject frontImage,frontText,backText,front,back; 

    public void SetCard(Weapon weapon)
    {
        frontImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Weapons/" + weapon.name);
        frontImage.GetComponent<Image>().preserveAspect = true;
        frontImage.GetComponent<RectTransform>().sizeDelta = new Vector2(220, 50);
        frontText.GetComponent<TextMeshProUGUI>().text = weapon.displayName; 
        backText.GetComponent<TextMeshProUGUI>().text = weapon.description;
        frontText.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50 );
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
}
