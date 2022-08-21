using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMouseDrag : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 offset;
    public Transform left, right, top, bottom;

    void FixedUpdate()
    {

        Vector3 screenPos = Camera.main.ScreenToWorldPoint(transform.position);
        //DRAG
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetMouseButtonDown(0))
         {
            selectedObject = this.gameObject;
            offset = selectedObject.transform.position - mousePosition;
            
        }
        if (selectedObject)
        {
            Vector3 trans = mousePosition + offset;
            selectedObject.transform.position = trans;

        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }


        //ZOOM
        var d = Input.GetAxis("Mouse ScrollWheel");

        if (d > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f);
        }
        else if (d < 0)
        {
            transform.localScale = new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f);
        }
       

        Vector3 thisPos = Camera.main.WorldToScreenPoint(transform.position);
        float leftPos = Camera.main.WorldToScreenPoint(left.position).x;
        float rightPos = Camera.main.WorldToScreenPoint(right.position).x;

        float topPos = Camera.main.WorldToScreenPoint(top.position).y;
        float bottomPos = Camera.main.WorldToScreenPoint(bottom.position).y;
        if (topPos - bottomPos < Camera.main.pixelHeight)
        {

            transform.localScale = new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f);
        }
        if (rightPos - leftPos < Camera.main.pixelWidth)
        {

            transform.localScale = new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f);
        }
        if (leftPos > 0)
        {
            transform.position = Camera.main.ScreenToWorldPoint(thisPos - new Vector3(leftPos+20, transform.position.y, 0));
        }

        if (rightPos < Camera.main.pixelWidth)
        {
            float difference = 20+Camera.main.pixelWidth - rightPos;
            transform.position = Camera.main.ScreenToWorldPoint(thisPos + new Vector3(difference, transform.position.y, 0));

        }

        thisPos = Camera.main.WorldToScreenPoint(transform.position);

        if (bottomPos > 0)
        {
            transform.position = Camera.main.ScreenToWorldPoint(thisPos - new Vector3(transform.position.x, bottomPos+20, 0));
        }

        if (topPos < Camera.main.pixelHeight)
        {
            float difference = 20+Camera.main.pixelHeight - topPos;
            transform.position = Camera.main.ScreenToWorldPoint(thisPos + new Vector3(transform.position.x, difference, 0));
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 1);

    }
}
