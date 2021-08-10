using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    public LayerMask graspable;
    public Transform gunTip;
    public Transform camera;
    public Transform player;

    [Header("Spring Joint Tweking")]
    public float maxDistanceFromPoint = 0.8f;
    public float minDistanceFromPoint = 0.25f;
    public float jointSpring = 4.5f;
    public float jointDamper = 7f;
    public float jointMassScale = 4.5f;

    private LineRenderer lineRenderer;
    private Vector3 grapplePoint;
    private Collider grappleCollider;
    private SpringJoint joint;
    private float range = 100f;

    public AudioSource grapplingSound;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        grapplingSound = GetComponent<AudioSource>();
        lineRenderer.enabled = false;
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

    // Called after positions have been updated
    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, range, graspable))
        {
            grapplePoint = hit.point;
            grappleCollider = hit.collider;

            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            // The distance grapple will try to keep from grapple point.
            joint.maxDistance = distanceFromPoint * maxDistanceFromPoint;
            joint.minDistance = distanceFromPoint * minDistanceFromPoint;

            // Grappling feel values
            joint.spring = jointSpring;
            joint.damper = jointDamper;
            joint.massScale = jointMassScale;

            lineRenderer.enabled = true;

            grapplingSound.Play(0);
        }
    }

    void DrawRope()
    {
        if (!joint)
        {
            lineRenderer.enabled = false;
        }
        else
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, gunTip.position);
            lineRenderer.SetPosition(1, grapplePoint);
        }
    }

    public void StopGrapple()
    {
        lineRenderer.enabled = false;
        Destroy(joint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Collider GetGrapplingCollider()
    {
        return grappleCollider;
    }

    public Vector3 GetGrapplingPoint()
    {
        return grapplePoint;
    }
}
