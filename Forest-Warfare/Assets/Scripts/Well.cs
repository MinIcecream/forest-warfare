using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    public GameObject popup;
    public GameObject book;

    void Awake()
    {
        book = GameObject.FindWithTag("BookCanvas");
    }
    void Update()
    {
        if (popup.activeInHierarchy == true && Input.GetKeyDown("e"))
        {
            book.transform.GetChild(1).gameObject.SetActive(true);
            book.transform.GetChild(1).GetChild(0).GetComponent<WellSelectWeapon>().well = transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            popup.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            popup.SetActive(false);
        }
    }
}
