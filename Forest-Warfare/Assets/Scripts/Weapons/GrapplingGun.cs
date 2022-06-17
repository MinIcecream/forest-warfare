using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, player;
    private float maxDistance = 100, grappleSpeed;
    private HingeJoint2D joint;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }
    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, maxDistance, whatIsGrappleable);

        if (hit)
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<HingeJoint2D>();

            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector2.Distance(player.position, grapplePoint);

        }
    }
    private Vector2 currentGrapplePosition;
    void DrawRope()
    {
        if (!joint) return;

        currentGrapplePosition = Vector2.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);
        lr.positionCount = 2;
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }
}
