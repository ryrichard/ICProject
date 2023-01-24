//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class testpointer : MonoBehaviour
{
    private float _maxDistance;
    private GameObject _gazedAtObject = null;
    private GameObject crosshair;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("crosshair");
        if(SceneManager.GetActiveScene().name == "Questions")
        {
            _maxDistance = 10000;
        }
        else
        {
            _maxDistance = 100;
        }
    }
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                if (_gazedAtObject)
                {
                    //_gazedAtObject.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
                    crosshair.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }
                _gazedAtObject = hit.transform.gameObject;
                //_gazedAtObject.SendMessage("OnPointerEnter", SendMessageOptions.DontRequireReceiver);
                if(_gazedAtObject.GetComponent<EventTrigger>() || (_gazedAtObject.GetComponent<ObjectController>() || (_gazedAtObject.GetComponent<Teleportation>() || _gazedAtObject.GetComponent<Button>())))
                {
                    crosshair.GetComponent<Image>().color = new Color32(0, 255, 6, 255);
                }
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            if (_gazedAtObject)
            {
                //S_gazedAtObject.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
                crosshair.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            _gazedAtObject = null;
        }
        
        if(Input.GetKeyDown("space") && Application.isEditor)
        {
            if (_gazedAtObject != null)
            {
                if (_gazedAtObject.GetComponent<EventTrigger>())
                {
                    PointerEventData data = null;
                    _gazedAtObject.GetComponent<EventTrigger>().OnPointerClick(data);
                }
                else if (_gazedAtObject.GetComponent<Teleportation>())
                {
                    _gazedAtObject.GetComponent<Teleportation>().onclick();
                }
                else if (_gazedAtObject.GetComponent<Button>())
                {
                    _gazedAtObject.GetComponent<Button>().onClick.Invoke();
                }
                else if (_gazedAtObject.GetComponent<ObjectController>())
                {
                    _gazedAtObject.GetComponent<ObjectController>().OnClick();
                }
            }

        }

        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            if (_gazedAtObject != null)
            {
                if (_gazedAtObject.GetComponent<EventTrigger>())
                {
                    PointerEventData data = null;
                    _gazedAtObject.GetComponent<EventTrigger>().OnPointerClick(data);
                }
                else if (_gazedAtObject.GetComponent<Teleportation>())
                {
                    _gazedAtObject.GetComponent<Teleportation>().onclick();
                }
                else if (_gazedAtObject.GetComponent<Button>())
                {
                    _gazedAtObject.GetComponent<Button>().onClick.Invoke();
                }
                else if (_gazedAtObject.GetComponent<ObjectController>())
                {
                    _gazedAtObject.GetComponent<ObjectController>().OnClick();
                }
            }
        }
    }

   
}