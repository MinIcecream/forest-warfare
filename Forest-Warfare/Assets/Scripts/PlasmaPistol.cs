using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaPistol : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public WeaponAmmo ammoScript;
    public Transform spawnPt;
    public GameObject parent;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoScript.canShoot == true && GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == false)
        {
            AudioManager.Play("PlasmaPistol");
            ammoScript.Shoot();
            Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            Vector2 objPos = player.transform.position;

            var newBullet = Instantiate(bullet, spawnPt.position, Quaternion.identity);
            newBullet.GetComponent<PlasmaOrb>().unnormalizedDir = (mousePos - objPos);

        }
    }
}
