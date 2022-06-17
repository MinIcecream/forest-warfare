using UnityEngine;

public class SwordParent : MonoBehaviour
{
    bool spin = false;

    void FixedUpdate()
    {
        if (!spin)
        {
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

            //Get the Screen position of the mouse
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            //Ta Daaa
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 180));
        }
        else
        {
            transform.Rotate(0, 0, -50);
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            spin = true;
        }
        else
        {
            spin = false;
        }
    }
}
