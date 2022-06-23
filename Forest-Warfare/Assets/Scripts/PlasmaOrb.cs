using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaOrb : MonoBehaviour
{
    public Vector3 unnormalizedDir;
    float speed = 10f;
    Rigidbody2D rb;
    string state = "up";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SwitchState());
    }
    void FixedUpdate()
    {
        Vector2 tempDir;

        if (unnormalizedDir != null)
        {
            if (state == "up")
            {
                tempDir = new Vector2(unnormalizedDir.x, unnormalizedDir.y + .5f).normalized;
            }
            else
            {
                tempDir = new Vector2(unnormalizedDir.x, unnormalizedDir.y - .5f).normalized;
            }
            rb.velocity = tempDir * speed;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Instantiate(Resources.Load<GameObject>("Weapons/PlasmaOrbParticles"), transform.position, Quaternion.identity);
        Destroy(gameObject);
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
