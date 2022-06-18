using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public WeaponAmmo ammoScript;
    public Transform spawnPt;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoScript.canShoot == true && GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == false)
        {

            Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            Vector2 objPos = player.transform.position;
            int bullets = Random.Range(4, 7);
            ammoScript.Shoot();

            for (int i = 0; i < bullets; i++)
            {
                float yPos = Random.Range(mousePos.y - 2f, mousePos.y + 2f);
                var newBullet = Instantiate(bullet, spawnPt.position, Quaternion.identity);
                newBullet.GetComponent<BulletProjectile>().dir = (new Vector2(mousePos.x,yPos) - objPos).normalized;
            } 
        }
    }
}
