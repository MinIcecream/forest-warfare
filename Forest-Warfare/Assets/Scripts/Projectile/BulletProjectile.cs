using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : Projectile
{
    public bool piercing;

    public Vector3 dir;
    float speed = 30f;
    public override void Propel(Vector2 vector)
    {
        dir = vector;
    }
    void FixedUpdate()
    {
        if (dir != null)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rb.velocity = dir*speed;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!piercing)
        {
            Instantiate(Resources.Load<GameObject>("Weapons/BulletParticles"), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(coll.gameObject.tag != "Enemy")
        {
            Instantiate(Resources.Load<GameObject>("Weapons/BulletParticles"), transform.position, Quaternion.identity);

            Destroy(gameObject);
        } 
    }
}
