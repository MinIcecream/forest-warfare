using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdProjectile : MonoBehaviour
{
    public GameObject particles;

    void FixedUpdate()
    {
        transform.position += transform.right * Time.deltaTime * 18;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerHealth>().DealDamage(20);
        }
        if(coll.gameObject.tag != "Enemy")
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }   
    }
}
