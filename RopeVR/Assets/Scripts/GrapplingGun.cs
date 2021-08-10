using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    public LayerMask graspable;
    public Transform gunTip;
    public Transform camera;
    public Transform player;
    public LineRenderer vrLineRenderer;

    [Header("Spring Joint Tweking")]
    public float maxDistanceFromPoint = 0.8f;
    public float minDistanceFromPoint = 0.25f;
    public float jointSpring = 4.5f;
    public float jointDamper = 7f;
    public float jointMassScale = 4.5f;

    [Header("VR Input References")]
    // left click

    [Header("Keybinds")]
    [SerializeField] KeyCode shootRopeKey = KeyCode.Mouse0;

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
        if (Input.GetKeyDown(shootRopeKey))
        {
            StartGrapple();
        }
        else if (Input.GetKeyUp(shootRopeKey))
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
            vrLineRenderer.enabled = false;

            grapplingSound.Play(0);
        }
    }

    void DrawRope()
    {
        if (!joint)
        {
            lineRenderer.enabled = false;
            vrLineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = true;
            vrLineRenderer.enabled = false;
            lineRenderer.SetPosition(0, gunTip.position);
            lineRenderer.SetPosition(1, grapplePoint);
        }
    }

    public void StopGrapple()
    {
        lineRenderer.enabled = false;
        vrLineRenderer.enabled = true;
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
