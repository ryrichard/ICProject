using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [TextArea] string notes = "This is script is for teleporting players to this position. This will be attached to a teleportation pad. When players look at said teleportation pad, their position will change to this teleportation pad's position. Players y position will need to be alterated a bit so they don't clip through the floor.";

    public DataController dc;

    Vector3 telepadPos;
    Vector3 telepadRot;

    public float offset = 2f;

    // Start is called before the first frame update
    void Start()
    {
        telepadPos = gameObject.transform.position;
        telepadPos.y += offset;
        telepadRot = gameObject.transform.eulerAngles;
    }

    public Vector3 GetLocation()
    {
        return telepadPos;
    }



    public void OnPointerEnter()
    {
        DebugText("pointer entered");

        dc.player.transform.position = telepadPos;
        dc.player.transform.rotation = Quaternion.Euler(telepadRot);
    }

    public void OnPointerExit()
    {
        DebugText("pointer exited");
    }



    void DebugText(string debug)
    {
        Debug.Log("(Teleportation.cs) " + debug);
    }
}