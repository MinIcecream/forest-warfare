using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    public Sprite health_1;
    public Sprite health_2;
    public Sprite health_3;
    public Sprite health_4;
    public Sprite health_5;
    public Sprite health_6;
    public Sprite health_0;

    public PlayerHealth playerHealth;

    int health = 120;

    void Update()
    {
        if (playerHealth)
        {
            health = playerHealth.getHealth();
            changeHealth();
        }     
    }

    void changeHealth()
    {
        switch (health)
        {
            case int n when (n <=0):
                GetComponent<Image>().overrideSprite = health_0;

                break;
            case int n when (n <= 20):
                GetComponent<Image>().overrideSprite = health_1;

                break;
            case int n when (n <= 40):
                GetComponent<Image>().overrideSprite = health_2;

                break;
            case int n when (n <= 60):
                GetComponent<Image>().overrideSprite = health_3;

                break;
            case int n when(n <= 80):
                GetComponent<Image>().overrideSprite = health_4;

                break;
            case int n when (n <= 100):
                GetComponent<Image>().overrideSprite = health_5;

                break;
            case int n when (n <= 120):
                GetComponent<Image>().overrideSprite = health_6;

                break;
        }
    }
}
