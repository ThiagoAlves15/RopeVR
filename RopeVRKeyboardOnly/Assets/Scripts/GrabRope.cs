using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRope : MonoBehaviour
{
    [Header("Rope Grabbing")]
    [SerializeField] private float ropeDistance = 1f;
    [SerializeField] private float ropeJumpForce;
    [SerializeField] private float ropeGrabGravity;
    [SerializeField] LayerMask ropeMask;

    [Header("Camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private float fov;
    [SerializeField] private float ropeGrabfov;
    [SerializeField] private float ropeGrabfovTime;

    [Header("Rope Jumping")]
    [SerializeField] private Transform orientation;

    private bool ropeGrab = false;
    RaycastHit ropeHit;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void CheckRope()
    {
        ropeGrab = Physics.CheckSphere(transform.position, ropeDistance, ropeMask);
    }

    void Update()
    {
        CheckRope();

        if (Input.GetKeyDown(KeyCode.Space) && ropeGrab)
        {
            DoJumpFromRope();
        } 
        else if (Input.GetMouseButton(1) && ropeGrab)
        {
            DoGrabRope();
        }
        else
        {
            DoFallingAction();
        }
    }

    void DoJumpFromRope()
    {
        Vector3 ropeJumpDirection = orientation.transform.up + orientation.transform.forward;
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        rb.AddForce(ropeJumpDirection * ropeJumpForce * 100, ForceMode.Force);
    }

    void DoGrabRope()
    {
        // Runs only once, prevents from going to else while holding the key
        if (Input.GetMouseButtonDown(1))
        {
            rb.useGravity = false;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, ropeGrabfov, ropeGrabfovTime * Time.deltaTime);
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void DoFallingAction()
    {
        rb.useGravity = true;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, ropeGrabfovTime * Time.deltaTime);
    }
}
