using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIDisplay : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int health = 120;
    public Slider healthSlider;

    public PlayerStamina playerStamina;
    public int stamina = 100;
    public Slider staminaSlider;

    public Image portrait;

    void Update()
    {
        if (playerHealth)
        {
            if(health!= playerHealth.getHealth())
            {

                health = playerHealth.getHealth();
                healthSlider.value = health;
                ChangePortrait();
            } 
        }
        if (playerStamina)
        { 
            stamina = playerStamina.getStamina();
            staminaSlider.value = stamina;
        }
 
    }
    void ChangePortrait()
    {
        if (health > 90)
        {
            portrait.sprite = Resources.Load<Sprite>("portrait_1");
        }
        else if (health > 60)
        {
            portrait.sprite = Resources.Load<Sprite>("portrait_2");
        }
        else if (health > 30)
        {
            portrait.sprite = Resources.Load<Sprite>("portrait_3");
        }
        else
        {
            portrait.sprite = Resources.Load<Sprite>("portrait_4");
        }
    }
}
