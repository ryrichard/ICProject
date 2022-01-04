using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest_Manger  
{
    public GoalType goalType;
    public int required_ammount;
    public int current_ammount;

    public bool isReached()
    {
        return (current_ammount >= required_ammount);
    }

    public void ItemGathered()
    {
        if(goalType == GoalType.gather)
        current_ammount++;

    }

}

public enum GoalType
{
    kill,
    gather
}