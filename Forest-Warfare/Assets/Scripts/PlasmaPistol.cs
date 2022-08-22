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
    bool canShoot = true;
    public float fireDelay;
    public float size = 0.1f;

    bool charging = false;

    GameObject newBullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoScript.canShoot == true && GameObject.FindWithTag("PauseManager").GetComponent<PauseManager>().paused == false && canShoot&&!charging)
        {
            charging = true;

            canShoot = false;

            newBullet = Instantiate(bullet, spawnPt.position, Quaternion.identity);
            newBullet.GetComponent<PlasmaOrb>().Follow(spawnPt);

            AudioManager.Play("PlasmaPistolCharge");
        }

        if (Input.GetMouseButtonUp(0))
        {   
            Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            Vector2 objPos = player.transform.position;

            if (newBullet)
            {
                newBullet.GetComponent<PlasmaOrb>().UnFollow();
                newBullet.GetComponent<PlasmaOrb>().dir = (mousePos - objPos); 

                AudioManager.Stop("PlasmaPistolCharge");
            }
            if (charging)
            { 
                charging = false;

                StartCoroutine(Delay());

                AudioManager.Play("PlasmaPistol");
                ammoScript.Shoot();
            }
        }
    }
   
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }
    void OnDisable()
    {
        if (newBullet)
        {
            Destroy(newBullet);
            AudioManager.Stop("PlasmaPistolCharge");
        }
    }
}
