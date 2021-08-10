using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timeToSelfDestruct = 10f;
    public GrapplingGun grappling;

    void Awake()
    {
        grappling = GameObject.Find("GrapplingGun").GetComponent<GrapplingGun>();
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(timeToSelfDestruct);

        if (grappling.GetGrapplingCollider() == gameObject.GetComponent<Collider>())
        {
            grappling.StopGrapple();
        }

        Destroy(gameObject);
    }
}
