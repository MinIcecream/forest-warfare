using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMasterSword : MonoBehaviour
{
    private SpriteRenderer sprite;
    public GameObject player;
    List<Vector2> physicsShape = new List<Vector2>();

    public bool isColl;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        Flip();
         
    } 
    public void Flip()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(player.transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (mouseOnScreen.x < positionOnScreen.x)
        {
            if (!isColl)
            { 
                 sprite.flipX = true;
                transform.localEulerAngles = new Vector3(0, 0, -130);
            }  
        }
        else
        {
            if (!isColl)
            {
                sprite.flipX = false;
                transform.localEulerAngles = new Vector3(0, 0, -50);
            }  
        }
    }
}
