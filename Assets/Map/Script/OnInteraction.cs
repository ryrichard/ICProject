using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class OnInteraction : MonoBehaviour
{
    [SerializeField]
    UnityEvent onStartHover = default;
    [SerializeField]
    UnityEvent onEndHover = default;
    [SerializeField]
    UnityEvent onClick = default;

    public void OnLook()
    {
        Debug.Log("Looking...");
        onStartHover?.Invoke();
    }

    public void OnExit() //to make things less complicated, dont include OnExit() and dont change the obj's color when looked on. Just change crosshair's color when looking at interactable object
    {
        Debug.Log("Exiting...");
        onEndHover?.Invoke();
    }

    public void OnInteract()
    {
        Debug.Log("Click");
        onClick?.Invoke();
    }
}
