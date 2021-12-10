using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using System;

public class Gaze : MonoBehaviour
{
    [TextArea] public string note = "to make things less complicated, dont change the obj's color when looked on/off. Just change crosshair's color when looking at interactable object";


    //Info that are being displayed such as camera position, rotation, and what it is looking at
    #region Camera Info
    Vector3 rot;
    Vector3 pos;
    string objName;
    public TextMeshProUGUI tmp;
    #endregion

    //Settings include what objs it is looking at, maxdistance, how long a gaze is before a 'click' happens, etc.
    #region Gaze Settings
    [SerializeField]
    OnInteraction curInter;
    [SerializeField]
    OnInteraction newInter;
    //[SerializeField]
    //GameObject obj;
    [SerializeField]
    float maxDistance = 100f;
    float timeToClick = 2f;
    float timer;
    int layerMask = 1 << 8;
    #endregion

    void FixedUpdate()
    {
        rot = this.gameObject.transform.eulerAngles;
        pos = this.gameObject.transform.position;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMask))
        {
            ////obj = hit.transform.gameObject;
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            //try
            //{ 
            //    newInter = hit.transform.GetComponent<OnInteraction>();
            //    newInter.OnLook();
            //    objName = newInter.gameObject.name;

            //    if (curInter == newInter)
            //    {
            //        timer += Time.deltaTime;
            //        Debug.Log("Timer: " + timer);

            //        if (timer >= timeToClick)
            //        {
            //            hit.transform.GetComponent<OnInteraction>().OnInteract();
            //            ResetGaze();
            //        }
            //    }
            //    else if (!curInter)
            //    {
            //        curInter = newInter;
            //    }
            //    else
            //    {
            //        ResetGaze();
            //    }
            //}
            //catch(Exception e)
            //{
            //    objName = hit.transform.name + " has no OnInteraction Script";
            //}
        }
        else
            ResetGaze();

        tmp.text = "Rotation: " + rot.ToString() +
            "\nPosition: " + pos.ToString() +
            "\n" + objName;
    }

    void ResetGaze()
    {
        timer = 0f;

        if(curInter)
        {
            curInter.OnExit();
            curInter = null;
        }

        if (newInter)
            newInter = null;

        objName = "Null";

        //if (obj)
        //    obj = null;
    }
}
