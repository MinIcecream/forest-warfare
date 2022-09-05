using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearProjectile : Projectile
{ 
    public bool hasHit = false;
    float despawnTime = 5f;

    public GameObject platform;
    public Collider2D baseColl;

    public Transform pt, tipPt;

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void Update()
    {
        if (hasHit)
        {
            despawnTime -= Time.deltaTime;

            if (despawnTime <= 0)
            {
                timerEnd();
            }
        }
    }

    void FixedUpdate()
    {
        if (!hasHit)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Invoke("SetPlatform", 0.5f);
            hasHit = true; 
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0f;
        }
    }

    void timerEnd()
    {
        Destroy(gameObject);
    }
    void SetPlatform()
    { 
        if (tipPt.position.x < pt.position.x)
        {
            platform.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
        } 
        platform.layer = LayerMask.NameToLayer("Platform");
        baseColl.enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        platform.SetActive(true);
    }
}
