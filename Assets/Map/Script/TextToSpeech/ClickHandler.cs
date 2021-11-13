using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider))]
public class ClickHandler : MonoBehaviour
{

    //useless script??

    public void OnPointerEnter()
    {
        Debug.Log("enter");
    }

    public void OnPointerClick()
    {
        Debug.Log("click");
    }

    public void OnPointerExit()
    {
        Debug.Log("exit");
        
    }
}
