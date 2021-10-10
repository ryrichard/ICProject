using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [TextArea] public string notes = "This script is to move the player view with the mouse while in Unity Editor as it seems impossible to test the VR side unless the program is built.";

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    private const float _maxDistance = 100f;
    private GameObject _gazedAtObject = null;

    //disables this script if not in editor. 
    void Awake()
    {
        if(!Application.isEditor)
        {
            this.enabled = false;
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Moves player view with mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        //if (Google.XR.Cardboard.Api.IsTriggerPressed)
        //{
        //    _gazedAtObject?.SendMessage("OnPointerClick");
        //}
    }
}
