using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeaponTemplate : MonoBehaviour
{
    public SpriteRenderer[] sprites;

    //the name of the sound to play when fired
    public string audioName;
    public virtual void OnDisable()
    {
        foreach(SpriteRenderer sprite in sprites)
        {
            sprite.enabled = false;
        } 
    }
    public virtual void OnEnable()
    {
        foreach(SpriteRenderer sprite in sprites)
        {
            sprite.enabled = true;
        }
    }
    public void PlayAudio()
    {
        if (GameObject.FindWithTag("AudioManager"))
        {
            AudioManager.Play(audioName);
        }
    }
    public void StopAudio()
    {
        if (GameObject.FindWithTag("AudioManager"))
        {
            AudioManager.Stop(audioName);
        }
    }
}
