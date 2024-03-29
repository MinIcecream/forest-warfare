using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyDeath : MonoBehaviour
{
    public void Death(GameObject particles)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        AudioManager.Play("EnemyDeath");
        transform.Find("Canvas").gameObject.SetActive(false);
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject, 2);
    }
}
