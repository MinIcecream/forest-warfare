using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocket;
    public GameObject player;
    public GameObject spawnPt;
    public WeaponAmmo ammoScript;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&ammoScript.canShoot && GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == false)
        {
 
            Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            Vector2 objPos = player.transform.position;

            transform.Find("Rocket Projectile").gameObject.SetActive(false);

            var newRocket = Instantiate(rocket, spawnPt.transform.position, Quaternion.identity);
            newRocket.GetComponent<RocketProjectile>().SetDir((mousePos - objPos).normalized);     
        }
        if (ammoScript.currentAmmo==1)
        {
            transform.Find("Rocket Projectile").gameObject.SetActive(true);
        }
    }
}
