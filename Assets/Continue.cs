using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    public LinearConveyor conveyor;
    private float speed = 0.3f;

    void Start()
    {

    }



    public void OnClick(){
      Debug.Log("OnClick");
      if(conveyor.speed == 0.0f){
        conveyor.ChangeSpeed(speed);
      }
    }
}
