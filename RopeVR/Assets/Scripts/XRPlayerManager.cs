using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRPlayerManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
