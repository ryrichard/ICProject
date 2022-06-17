using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    public Image imgCircle;
    public UnityEvent VRClick;
    public float totalTime = 2;
    bool vrStatus;
    public float vrTimer;


    void Update()
    {
        if (vrStatus)
        {
            vrTimer += Time.deltaTime;
            imgCircle.fillAmount = vrTimer / totalTime;
        }

        if (vrTimer > totalTime)
        {
            VRClick.Invoke();
        }
    }

    public void vrOn()
    {
        vrStatus = true;
    }

    public void vrOff()
    {
        vrStatus = false;
        vrTimer = 0;
        imgCircle.fillAmount = 0;
    }
}
