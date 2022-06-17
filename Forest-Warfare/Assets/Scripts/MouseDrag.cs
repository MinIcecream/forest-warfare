using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    Vector3 cursorPosition;
    Vector3 cursorScreenPoint;

    public bool drag = false;

    public Camera cam;
    public Rigidbody2D rb;

    void Awake()
    {
        cam = Camera.main;
    }
    void LateUpdate()
    {
        if (drag)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = Vector3.Distance(transform.position, cam.transform.position);
            pos = cam.ScreenToWorldPoint(pos);
            rb.velocity = (pos - transform.position) * 5;
        }
        drag = false;
    }
}
