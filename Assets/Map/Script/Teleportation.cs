using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [TextArea] string notes = "This is script is for teleporting players to this position. This will be attached to a teleportation pad. When players look at said teleportation pad, their position will change to this teleportation pad's position. Players y position will need to be alterated a bit so they don't clip through the floor.";

    public DataController dc;

    Vector3 telepadPos;
    Vector3 telepadRot;
    Renderer renderer;

    public Material originalColor;
    public Material gazedColor;

    public float offset = 2f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

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
        dc.player.transform.position = telepadPos;
        dc.player.transform.rotation = Quaternion.Euler(telepadRot);
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