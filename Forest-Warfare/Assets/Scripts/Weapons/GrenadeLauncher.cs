using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    public Transform spawnPt;
    public GameObject grenade;
    public GameObject player;
    public WeaponAmmo ammoScript;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoScript.canShoot == true && GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == false)
        {
            AudioManager.Play("RocketLauncher");
            ammoScript.Shoot();
            Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            Vector2 objPos = player.transform.position;

            var newGrenade = Instantiate(grenade, spawnPt.position, Quaternion.identity);
            newGrenade.GetComponent<GrenadeProjectile>().Propel((mousePos - objPos).normalized);
        } 
    }
}
