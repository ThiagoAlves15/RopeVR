using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpheres : MonoBehaviour
{
    public Transform graspableObject;
    private Vector3 nextSphereSpawn;

    void Start()
    {
        nextSphereSpawn.z = Random.Range(10, 15);
        nextSphereSpawn.y = Random.Range(5, 10);
        nextSphereSpawn.x = Random.Range(-4, 4);
        StartCoroutine(spawnSpheres());
    }

    IEnumerator spawnSpheres()
    {
        yield return new WaitForSeconds(1);
        
        Instantiate(graspableObject, nextSphereSpawn, graspableObject.rotation);
        nextSphereSpawn.z += Random.Range(6, 12);
        nextSphereSpawn.y = Random.Range(5, 10);
        nextSphereSpawn.x = Random.Range(-4, 4);

        StartCoroutine(spawnSpheres());
    }
}
