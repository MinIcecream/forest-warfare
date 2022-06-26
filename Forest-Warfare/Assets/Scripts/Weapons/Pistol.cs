using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public WeaponAmmo ammoScript;
    public Transform spawnPt;
    public GameObject parent;
    bool canShoot = true;
    public float fireDelay;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoScript.canShoot == true && GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == false && canShoot)
        {
            canShoot = false;
            StartCoroutine(Delay());
            AudioManager.Play("Pistol");
            ammoScript.Shoot();
            Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            Vector2 objPos = player.transform.position;

            var newBullet = Instantiate(bullet, spawnPt.position, Quaternion.identity);
            newBullet.GetComponent<BulletProjectile>().dir = (mousePos - objPos).normalized;

        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }
}
