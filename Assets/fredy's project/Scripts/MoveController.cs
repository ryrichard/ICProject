using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool moveForward;
    public float rotationSpeed; ///
    private CharacterController cc;
    //private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //// Additional code
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0 , verticalInput);
        movementDirection.Normalize();
        ////
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

      
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }

        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
            ///
            //animator.SetBool("IsMoving", true);

            //Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);


        }
        //else
           // animator.SetBool("IsMoving", false);

        ///
    }
}
