using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomStereoCamera : MonoBehaviour
{
    Camera cam;
    public Camera cameraL;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
