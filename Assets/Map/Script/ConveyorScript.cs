using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    private Player player;
    private float speed = 0.0f;
    public LinearConveyor conveyor;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Player")
        {
            Debug.Log("Collision");
            conveyor.ChangeSpeed(speed);
       }
    }
}
