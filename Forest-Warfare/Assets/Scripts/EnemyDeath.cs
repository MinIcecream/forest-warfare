using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyDeath : MonoBehaviour
{
    public void Death(AudioSource audio, GameObject particles)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        audio.Play();
        transform.Find("Canvas").gameObject.SetActive(false);
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject, audio.clip.length);
    }
}
