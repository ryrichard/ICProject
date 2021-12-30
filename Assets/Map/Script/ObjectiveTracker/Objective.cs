using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective
{
    public string objectiveTitle
    {
        //set { objectiveTitle = someTitle; }
        get { return objectiveTitle; }
    }
    public string objectiveDescription
    {
        //set { objectiveDescription = someDescription; }
        get { return objectiveDescription; }
    }

    public bool started
    {
        set { completed = false; }
        get { return started; }
    }
    public bool completed
    {
        set { completed = false; }
        get { return completed; }
    }
}
