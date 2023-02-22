using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject ignoredObject = GameObject.FindGameObjectWithTag("Obj");
        Physics.IgnoreCollision(ignoredObject.GetComponent<Collider>(), GetComponent<Collider>());
    }

   
}
