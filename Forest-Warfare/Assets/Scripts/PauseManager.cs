using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject panel;
    public Animator anim;
    public bool paused;

    public void Pause()
    {
        paused = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<SwapWeapon>().enabled = false;
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        anim.SetTrigger("Exit");
        StartCoroutine(DisablePanel());
    }

    IEnumerator DisablePanel()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        panel.SetActive(false); 
        paused = false;

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<SwapWeapon>().enabled = true;
  
        Time.timeScale = 1;
    }

    void Awake()
    {
        Time.timeScale = 1;
    }
}
