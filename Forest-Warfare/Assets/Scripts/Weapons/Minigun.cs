using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public WeaponAmmo ammoScript;
    public Transform spawnPt;


    bool shooting = false;

    void Update()
    {
        if (Input.GetMouseButton(0) && ammoScript.canShoot == true && GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == false)
        {
            if (!shooting)
            {
                shooting = true;
                StartCoroutine(shoot());
            }
        }
        else
        {
            shooting = false;
        }
    }
    IEnumerator shoot()
    {
        while (shooting)
        {

            ammoScript.Shoot();
            Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            Vector2 objPos = player.transform.position;

            var newBullet = Instantiate(bullet, spawnPt.position, Quaternion.identity);
            newBullet.GetComponent<BulletProjectile>().dir = (mousePos - objPos).normalized;

            yield return new WaitForSeconds(0.06f);
        }
    }
}
