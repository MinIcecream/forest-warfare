using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;
    
    public Explode explode;
    GameObject explosionColl;

    bool canExplode = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        explosionColl = Instantiate(Resources.Load<GameObject>("Weapons/RocketExplosionCollider"), transform.position, Quaternion.identity);
        explosionColl.GetComponent<FollowObject>().SetTarget(this.gameObject);
        GetComponent<Explode>().range = explosionColl;
        GetComponent<Collider2D>().enabled = false;
        Invoke("SpawnDelay", 0.5f); 
    }

    void FixedUpdate()
    {
        if (target)
        { 
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed; 
        } 
    }  

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name != "Range" && canExplode)
        {
            explode.Explosion();
        }
    }
    void SpawnDelay()
    {
        GetComponent<Collider2D>().enabled = true;
        canExplode = true;
    }
}
