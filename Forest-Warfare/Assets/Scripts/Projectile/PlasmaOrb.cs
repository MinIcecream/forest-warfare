using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaOrb : MonoBehaviour
{
    public Vector3 dir;
    float speed = 10f;
    Rigidbody2D rb;
    string state = "up";

    public Transform pt;
     
    float size = 0.5f;

    bool following=false;

    public void Follow(Transform t)
    {
        GetComponent<WeaponCollider>().active = false;
        following = true;
        pt = t;
    }
    public void UnFollow()
    {
        GetComponent<WeaponCollider>().active = true;
        following = false;

    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    void FixedUpdate()
    {
        Vector2 tempDir;
         
        if (dir != Vector3.zero)
        { 
            if (state == "up")
            {
                tempDir = new Vector2(dir.x, dir.y + .5f).normalized;
            }
            else
            {
                tempDir = new Vector2(dir.x, dir.y - .5f).normalized;
            }
            rb.velocity = tempDir * speed*.8f/size;
        }

        if (following && size<=1)
        { 
            size += 0.005f; 
            GetComponent<WeaponCollider>().damage = Mathf.CeilToInt(30*size)+ 50 * Mathf.FloorToInt(size / .99f); 
            transform.localScale = new Vector2(1, 1)*size;
        }
    }
    void Update() 
    {
        if (following && pt != null)
        {
            transform.position = pt.position;
            StartCoroutine(SwitchState());
        } 
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!following)
        { 
            Instantiate(Resources.Load<GameObject>("Weapons/PlasmaOrbParticles"), transform.position, Quaternion.identity);
            Destroy(gameObject);
        } 
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (!following)
        {
            Instantiate(Resources.Load<GameObject>("Weapons/PlasmaOrbParticles"), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    IEnumerator SwitchState()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.2f,1f));
            if (state == "up")
            {
                state = "down";
            }
            else
            {
                state = "up";
            }
        }
    }  
}
