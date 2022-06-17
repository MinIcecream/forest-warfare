using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinesisGun : MonoBehaviour
{
    int bitmask = 1 << 12 | 1<<9 | 1 << 13;

    bool dragging = false;

    GameObject hitObject;

    bool objChosen = false;

    public WeaponCharge chargeScript;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, bitmask);

        if (hit.collider != null)
        {
            chargeScript.customCondition = true;
            if (objChosen == false)
            {
                hitObject = hit.collider.gameObject;
            }
            if (hitObject)
            {
                hitObject.GetComponent<Outline>().OutlineObject();  
            }

            objChosen = true;

            if (Input.GetMouseButtonDown(0))
            {
                dragging = true;
            }
        }
        else
        {
            chargeScript.customCondition = false;
            if (dragging == false)
            {
                objChosen = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            objChosen = false;
            hitObject = null;

        }


        if (dragging && hitObject != null && chargeScript.canShoot == true && GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == false)
        {
            if(hitObject.GetComponent<MouseDrag>() != null && hitObject.GetComponent<Outline>()!=null)
            hitObject.GetComponent<MouseDrag>().drag = true;
            hitObject.GetComponent<Outline>().OutlineObject();
             
        }
    }
}
