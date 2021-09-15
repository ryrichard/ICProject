using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [TextArea] string notes = "This is script is for teleporting players to this position. This will be attached to a teleportation pad. When players look at said teleportation pad, their position will change to this teleportation pad's position. Players y position will need to be alterated a bit so they don't clip through the floor.";

    Vector3 telepadPos;

    // Start is called before the first frame update
    void Start()
    {
        telepadPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
