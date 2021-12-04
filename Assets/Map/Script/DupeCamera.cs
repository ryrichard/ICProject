using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DupeCamera : MonoBehaviour
{
    public Camera mainCam;

    // Update is called once per frame
    void Update()
    {
        transform.position = mainCam.transform.position;
        transform.rotation = mainCam.transform.rotation;
    }
}
