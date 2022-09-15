using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject panel;
    public Animator anim;
    public bool paused;

    bool canUnpause = true;

    public static PauseManager instance;

    void Awake()
    { 
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        Time.timeScale = 1;
    }

    public void Pause()
    {
        if (!paused)
        { 
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
            GameObject.FindWithTag("Player").GetComponent<SwapWeapon>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
            paused = true; 
        } 
    } 
    public void Unpause()
    {
        if (paused&&canUnpause)
        {
            anim.SetTrigger("Exit"); 
            canUnpause = false;
            StartCoroutine(DisablePanel());
        } 
    }

    IEnumerator DisablePanel()
    {
        yield return new WaitForSecondsRealtime(.8f);
        panel.SetActive(false); 
        paused = false;

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<SwapWeapon>().enabled = true;
        canUnpause = true;
        Time.timeScale = 1; 
    }
     
    public static bool IsPaused()
    {
        return instance.paused;
    }

    void OnDisable()
    { 
        panel.SetActive(false); 
    }
}
