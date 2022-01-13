using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest_Manger : MonoBehaviour 
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

    public Quest quest = new Quest();

    void Start()
    {
        //create each event
        QuestEvent a = quest.AddQuestEvent("Step 1-", "Description 1");
        QuestEvent b = quest.AddQuestEvent("Step 2-", "Description 2");
        QuestEvent c = quest.AddQuestEvent("Step 3-", "Description 3");
        QuestEvent d = quest.AddQuestEvent("Step 4-", "Description 4");
        QuestEvent e = quest.AddQuestEvent("Step 5-", "Description 5");

        //define the paths between the events - e.g. the order they must be completed
        quest.AddPath(a.GetId(), b.GetId());
        quest.AddPath(b.GetId(), c.GetId());
        quest.AddPath(c.GetId(), d.GetId());
        quest.AddPath(d.GetId(), e.GetId());

        quest.BFS(a.GetId());

        quest.PrintPath();
    }


}

public enum GoalType
{
    kill,
    gather,
    walkTo,
    TalkTo,
}