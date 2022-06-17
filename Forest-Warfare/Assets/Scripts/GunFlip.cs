using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlip : MonoBehaviour
{
    private SpriteRenderer sprite;
    public GameObject player;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(player.transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if(mouseOnScreen.x < positionOnScreen.x)
        {
            sprite.flipY = true;
        }
        else
        {
            sprite.flipY = false;
        }
    }
}
