using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    float max = 3f;
    public GameObject spear;
    public GameObject player;

    private Vector3 initialPos;
    private Vector3 finalPos;

    public WeaponAmmo ammoScript;

    void FixedUpdate()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = player.transform.position;

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float pee = Mathf.Pow(positionOnScreen.y - mouseOnScreen.y, 2);
        float pop = Mathf.Pow(positionOnScreen.x - mouseOnScreen.x, 2);

        float distance = Mathf.Sqrt(pop+ pee );
        if (distance> max)
        {
            distance = max;
        }

        transform.localPosition = new Vector2(distance, 0);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialPos = (Vector3)Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        }
        if (Input.GetMouseButtonUp(0) && ammoScript.canShoot == true && PauseManager.paused == false)
        {
            finalPos = (Vector3)Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            
            var newSpear = Instantiate(spear, transform.position, Quaternion.identity);

            newSpear.GetComponent<SpearProjectile>().Propel((finalPos-initialPos));
        }
    }
}
