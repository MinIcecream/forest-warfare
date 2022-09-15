using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaOrb : MonoBehaviour
{
    public Vector3 dir;
    float speed = 10f;
    Rigidbody2D rb;
    string state = "up";

    public float checkRadius;
    public LayerMask layers;
    public Transform pt;

    public List<Collider2D> results;

    float size = 0.5f;

    bool following=false;

    public GameObject field;

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
            DestroyOrb();
        } 
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (!following)
        {
            DestroyOrb();
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
    void DestroyOrb()
    { 
        if (size >= 1)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            Instantiate(Resources.Load<GameObject>("Weapons/PlasmaOrbParticles"), transform.position, Quaternion.identity);
            field.SetActive(true);

            Collider2D[] results=(Physics2D.OverlapCircleAll(transform.position, checkRadius, layers));
            Invoke("Disable", 0.5f);

            foreach (Collider2D yo in results)
            { 
                yo.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position - yo.transform.position) * 100f);
                if (yo.gameObject.GetComponent<EnemyHealth>() != null)
                {
                    yo.gameObject.GetComponent<EnemyHealth>().DealDamage(20);
                }
            }
        }
        else
        {

            Instantiate(Resources.Load<GameObject>("Weapons/PlasmaOrbParticles"), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Disable()
    {  
        Destroy(gameObject); 
    }

}
