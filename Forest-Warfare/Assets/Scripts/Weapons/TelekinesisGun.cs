using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinesisGun : MonoBehaviour
{
    int bitmask = 1 << 12 | 1<<9 | 1 << 13;

    bool dragging = false;
    public Material outlineMat;
    public Material normal;
    GameObject hitObject;

    bool objChosen = false;

    public WeaponCharge chargeScript;
    bool firing;
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
                hitObject.GetComponent<SpriteRenderer>().material=outlineMat; 
                //hitObject.GetComponent<Outline>().OutlineObject();  
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
            if (dragging == false && objChosen)
            {
                hitObject.GetComponent<SpriteRenderer>().material=normal;
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
            if (!firing)
            {
                firing = true;
                AudioManager.Play("TelekinesisGun");
            } 
            if (hitObject.GetComponent<MouseDrag>() != null)
            {

                hitObject.GetComponent<MouseDrag>().drag = true;
                //hitObject.GetComponent<Outline>().OutlineObject();
                hitObject.GetComponent<SpriteRenderer>().material=outlineMat;
            }
        }
        else
        {
            AudioManager.Stop("TelekinesisGun");
            firing = false;
        }
    }
}
