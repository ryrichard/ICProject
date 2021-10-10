using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    Rigidbody rd;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //if(isGrounded)
        //{
        //    DebugText("We've hit the ground");
        //    rd.freezeRotation = true;

        //}
    }

    void DebugText(string debug)
    {
        Debug.Log("PlayerMovement.cs: " + debug);
    }
}
