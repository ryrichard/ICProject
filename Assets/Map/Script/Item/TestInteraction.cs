using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : MonoBehaviour
{
    public void OnPointerEnter()
    {
        Debug.Log("Hovering over " + gameObject.name);
    }

    public void OnPointerExit()
    {
        Debug.Log("Stopped hovering over " + gameObject.name);
    }
    public void OnPointerClick()
    {
        Debug.Log("Clicked on " + gameObject.name);
    }
}
