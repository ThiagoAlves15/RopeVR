using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    public GrapplingGun grappling;

    private Quaternion desiredRotation;
    private float rotationSpeed = 5f;

    void Update()
    {
        if (grappling.IsGrappling())
        {
            desiredRotation = Quaternion.LookRotation(grappling.GetGrapplingPoint() - transform.position);
        }
        else
        {
            desiredRotation = transform.parent.rotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}
