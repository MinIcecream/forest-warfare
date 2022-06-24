using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Explode : MonoBehaviour
{
    public GameObject explosion;
    public GameObject range;

    public void Explosion()
    {
        AudioManager.Play("Explosion");
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .1f);
        Instantiate(explosion, transform.position, Quaternion.identity);
        range.GetComponent<ExplosiveBarrelDamage>().Explode();
        Destroy(range);
        Destroy(gameObject); 
    }
}
