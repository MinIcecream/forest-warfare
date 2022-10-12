using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Bonecrusher : MeleeWeapon
{
    bool charging = false;
    public float angle = 0;
    bool facingLeft;

    public Sprite normalSprite, swingSprite;
    public GameObject player;
    bool swinging = false;

    bool useSwingDamage = false;

    public int damage;
    public int swingDamage;

    public Material normal;

    public Material shine;

    void Update()
    { 
        if (Input.GetMouseButtonDown(0) && !PauseManager.IsPaused())
        {
            if (!charging && !swinging)
            {
                transform.parent.gameObject.GetComponent<PlayerLook>().enabled = false;
                GetComponent<GunFlip>().enabled = false;

                //Get the Screen positions of the object
                Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(player.transform.position);

                //Get the Screen position of the mouse
                Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

                if (mouseOnScreen.x < positionOnScreen.x)
                {
                    GetComponent<GunFlip>().FlipLeft();
                    facingLeft =true;
                    angle = 180;
                }
                else
                {
                    GetComponent<GunFlip>().FlipRight();
                    facingLeft = false;
                    angle = 0;
                }  
                charging = true;
            } 
        }
        if (charging&&!swinging)
        {
            if (facingLeft&&angle>90)
            {
                angle -= 35 * Time.deltaTime;
            }
            else if (!facingLeft && angle < 90)
            {
                angle += 35 * Time.deltaTime;
            }
            transform.parent.transform.localEulerAngles = new Vector3(0, 0, angle); 
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (charging && Mathf.RoundToInt(angle)==90)
            {  
                StartCoroutine(Swing());
            }
            else
            { 
                charging = false;
                transform.parent.gameObject.GetComponent<PlayerLook>().enabled = true;
                GetComponent<GunFlip>().enabled = true;
                swinging = false;
            }
        }
        if(charging && Mathf.RoundToInt(angle) == 90)
        { 
            GetComponent<SpriteRenderer>().material = shine;
        }
        else
        { 
            GetComponent<SpriteRenderer>().material = normal;
        }
    } 
    IEnumerator Swing()
    { 
        swinging = true;

        GetComponent<SpriteRenderer>().sprite = swingSprite;
        useSwingDamage = true;
        if (facingLeft)
        {
            while (angle <190)
            {
                yield return new WaitForSeconds(0.01f);
                angle += 10;
                transform.parent.transform.localEulerAngles = new Vector3(0, 0, angle);
            }
        }

        else
        {
            while (angle > -10)
            {
                yield return new WaitForSeconds(0.01f);
                angle -= 10;
                transform.parent.transform.localEulerAngles = new Vector3(0, 0, angle);
            }
        } 
        useSwingDamage = false;
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .1f);
        GetComponent<SpriteRenderer>().sprite = normalSprite;

        yield return new WaitForSeconds(0.2f);

        useSwingDamage = false;

        yield return new WaitForSeconds(0.8f);

        charging = false;
        transform.parent.gameObject.GetComponent<PlayerLook>().enabled = true;
        GetComponent<GunFlip>().enabled = true;
        swinging = false; 
    }  

    void OnTriggerEnter2D(Collider2D coll)
    { 
        if (coll.gameObject.tag == "Enemy")
        {
            AudioManager.Play("MeleeHit");

            if (useSwingDamage)
            { 
                coll.gameObject.GetComponent<EnemyHealth>().DealDamage(swingDamage);
            }
            else
            { 
                coll.gameObject.GetComponent<EnemyHealth>().DealDamage(damage);
            } 
        }
        else if (coll.gameObject.tag == "Interactable Terrain")
        {
            coll.gameObject.GetComponent<TerrainTrigger>().trigger = true;
        } 
    }
    void OnEnable()
    {
        base.OnEnable();
        GetComponent<Collider2D>().enabled = true; 
    }
    public override void OnDisable()
    {
        base.OnDisable();
        GetComponent<Collider2D>().enabled = false;
    }
}
