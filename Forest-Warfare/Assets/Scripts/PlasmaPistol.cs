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
    public bool canShoot = true;
    public float fireDelay;
    public float size = 0.1f;

    public bool charging = false;

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
             
            if (charging&&newBullet)
            {   
                StartCoroutine(Delay());

                AudioManager.Play("PlasmaPistol");
                ammoScript.Shoot(); 
                
                newBullet.GetComponent<PlasmaOrb>().UnFollow();
                newBullet.GetComponent<PlasmaOrb>().dir = (mousePos - objPos);
                 
            }
            charging = false;
            AudioManager.Stop("PlasmaPistolCharge");

            newBullet = null;
        }
    }
   
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }
    void OnDisable()
    {
        if (newBullet&&charging)
        {
            Destroy(newBullet);
            AudioManager.Stop("PlasmaPistolCharge");
        }
        newBullet = null;
    }
    void OnEnable()
    {
        canShoot = true;
    }
}
