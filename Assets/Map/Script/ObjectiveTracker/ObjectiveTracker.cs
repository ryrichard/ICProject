using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTracker : MonoBehaviour
{
    //file that contains all objective

    Objective currentObjective;

    public void SetCurrentObjective()
    {
        
    }

    public void FinishObjective()
    {
        currentObjective.completed = true;
    }
}
