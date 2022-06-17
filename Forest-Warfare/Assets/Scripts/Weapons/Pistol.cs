using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public WeaponAmmo ammoScript;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoScript.canShoot == true && PauseManager.paused == false)
        {
            Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            Vector2 objPos = player.transform.position;

            var newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<BulletProjectile>().dir = (mousePos - objPos).normalized;
        }
    }
}
