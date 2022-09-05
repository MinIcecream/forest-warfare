using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBlade : MeleeWeapon
{
    public int slashDamage;

    int bitmask = 1 << 9;
    public LayerMask mask;

    public Material outlineMat;
    public Material normal;
    GameObject hitObject;

    public GameObject parent;

    List<GameObject> hitEnemies = new List<GameObject>();

    bool objChosen;

    public GameObject slice;

    public GameObject dashDust;

    public GameObject sprite;

    void Update()
    { 
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, bitmask);

        //If youre hovering over an enemy
        if (hit.collider != null)
        {  
            //Assign enemy
            if (objChosen == false && !hitEnemies.Contains(hit.collider.gameObject))
            {
                objChosen = true;
                hitObject = hit.collider.gameObject;
                hitObject.GetComponent<SpriteRenderer>().material = outlineMat;
            } 
             
            //Click
            if (Input.GetMouseButtonDown(0) && hitObject)
            {
                if (!hitEnemies.Contains(hitObject))
                {
                    hitEnemies.Add(hitObject);
                    Slice(hitObject.transform.position);
                    StartCoroutine(Remove(hitObject));
                    hitObject.GetComponent<EnemyHealth>().DealDamage(slashDamage);
                } 
            }
        }

        //If not hovering
        else
        { 
            //If you chose an object, make it normal.
            if (objChosen&&hitObject)
            {
                hitObject.GetComponent<SpriteRenderer>().material = normal;
                objChosen = false;
            }
        } 
    } 
    void Slice(Vector3 pos)
    {
        var newSlice=Instantiate(slice, pos, Quaternion.identity); 

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(pos, parent.transform.position);

        //Ta Daaa
        newSlice.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 180));

        float terrainPos = hitPoint(pos);

        if (parent.transform.position.x < pos.x)
        {
            parent.GetComponent<FlipPlayer>().FlipRight();
            Instantiate(dashDust, parent.transform.position, Quaternion.identity); 

            if(terrainPos< pos.x + 3)
            {
                parent.transform.position = new Vector2(terrainPos, pos.y);
            }
            else
            { 
                parent.transform.position = new Vector2(pos.x + 3, pos.y);
            }
        }

        else
        {
            parent.GetComponent<FlipPlayer>().FlipLeft();
            var dust = Instantiate(dashDust, transform.position, Quaternion.identity);
            dust.transform.eulerAngles = new Vector3(0, 180, 0) ;

            parent.transform.position = new Vector2(pos.x - 3, pos.y);

            if (terrainPos > pos.x - 3)
            { 
                parent.transform.position = new Vector2(terrainPos, pos.y);
            }
            else
            { 
                parent.transform.position = new Vector2(pos.x - 3, pos.y);
            }
        }

        StartCoroutine(Blink());
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    IEnumerator Blink()
    {
        sprite.GetComponent<SpriteRenderer>().enabled = false;
        parent.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);

        sprite.GetComponent<SpriteRenderer>().enabled = true;
        parent.GetComponent<SpriteRenderer>().enabled = true;
    }

    public float hitPoint(Vector3 pos)
    {
        Vector3 dir = (pos - parent.transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(parent.transform.position, dir, Mathf.Infinity, mask);

        if (hit.collider != null)
        {
            return hit.point.x;
        }
        
        else if (dir.x > 0)
        {
            return 100000;
        }
        else
        {
            return -100000;
        }
    }
    IEnumerator Remove(GameObject obj)
    {
        yield return new WaitForSeconds(5f);
        hitEnemies.Remove(obj);
    }
    void OnEnable()
    {
        base.OnEnable();
        GetComponent<Collider2D>().enabled = true;
        foreach(GameObject obj in hitEnemies)
        {
            StartCoroutine(Remove(obj));
        }
    }
    void OnDisable()
    { 
        base.OnDisable();
        GetComponent<Collider2D>().enabled = false;
        if (hitObject)
        {
            hitObject.GetComponent<SpriteRenderer>().material = normal;
        }
    }
}
