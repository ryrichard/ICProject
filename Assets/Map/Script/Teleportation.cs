using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [TextArea] string notes = "This is script is for teleporting players to this position. This will be attached to a teleportation pad. When players look at said teleportation pad, their position will change to this teleportation pad's position. Players y position will need to be alterated a bit so they don't clip through the floor.";

    public DataController dc;

    Vector3 teleExitPos;
    Vector3 teleExitRot;
    Renderer renderer;

    public Material originalColor;
    public Material gazedColor;

    public GameObject exit;

    public float offset = 2f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        if(exit)
        {
            teleExitPos = exit.transform.position;
            teleExitPos.y += offset;
            teleExitRot = exit.transform.eulerAngles;
        }
        else
        {
            teleExitPos = gameObject.transform.position;
            teleExitPos.y += offset;
            teleExitRot = gameObject.transform.localEulerAngles;
        }
    }

    public Vector3 GetLocation()
    {
        return teleExitPos;
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    public void OnPointerClick()
    {
        TeleportPlayer();
    }

    private void TeleportPlayer()
    {
        dc.player.transform.position = teleExitPos;
        dc.player.transform.rotation = Quaternion.Euler(teleExitRot);
    }

    private void SetMaterial(bool gazed)
    {
        if(originalColor != null && gazedColor != null)
        {
            renderer.material = gazed ? gazedColor : originalColor;
        }
    }


    void DebugText(string debug)
    {
        Debug.Log("(Teleportation.cs) " + debug);
    }
}