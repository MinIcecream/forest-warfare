using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShoot : MonoBehaviour
{
    public GameObject bullet;

    public void Fire(Vector2 dir)
    {
        var projectile = Instantiate(bullet, transform.position, Quaternion.identity);
        projectile.transform.right = -dir;
    }
}
