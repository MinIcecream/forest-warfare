using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public Explode explode;
    GameObject explosionColl;
    public void SetDir(Vector2 dir)
    {
        rb.AddForce(dir * 12, ForceMode2D.Impulse);
         
    }
    void FixedUpdate()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name != "Range" && coll.gameObject.name != "Player")
        {
            explode.Explosion();
        }
    }
    void Awake()
    {
        explosionColl=Instantiate(Resources.Load<GameObject>("Weapons/RocketExplosionCollider"), transform.position, Quaternion.identity);
        explosionColl.GetComponent<FollowObject>().SetTarget(this.gameObject);
        GetComponent<Explode>().range = explosionColl;
    }
}
