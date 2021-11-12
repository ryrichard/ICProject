using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TriggerHandler : MonoBehaviour
{

  private float speed = 0.0f;
  public LinearConveyor conveyor;


    private void OnTriggerEnter (Collider other){
        Debug.Log("Triggered!");
        if(other.CompareTag("HallTrigger")){
          Debug.Log("Triggered #2!");
          conveyor.ChangeSpeed(speed);
        }

    }
}
