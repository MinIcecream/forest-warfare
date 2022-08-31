using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : ProjectileWeapon 
{
    public int min, max;

    protected override void Shoot()
    {
        PlayAudio();
        Vector2 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        Vector2 objPos = player.transform.position; 
        Vector2 normalizedMousePos = (mousePos - objPos).normalized; 

        int bullets = Random.Range(min, max); 

        for (int i = 0; i < bullets; i++)
        {  
            var newBullet = Instantiate(bullet, spawnPt.position, Quaternion.identity);
            newBullet.GetComponent<BulletProjectile>().dir = Rotate(normalizedMousePos,Random.Range(-10,10));
        }

        ammoScript.Shoot();
    }
    public Vector2 Rotate(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
    
}
