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
    public GameObject background;
    public GameObject checkmarkbox;

    //Event location objects
    public GameObject A;
    

    void Start()
    {
        //create each event
        QuestEvent a = quest.AddQuestEvent("Step 1-", "Description 1", A);
        QuestEvent b = quest.AddQuestEvent("Step 2-", "Description 2");
        QuestEvent c = quest.AddQuestEvent("Step 3-", "Description 3");
        QuestEvent d = quest.AddQuestEvent("Step 4-", "Description 4");
        QuestEvent e = quest.AddQuestEvent("Step 5-", "Description 5");

        //define the paths between the events - e.g. the order they must be completed
        //from --> to
        quest.AddPath(a.GetId(), b.GetId());
        quest.AddPath(b.GetId(), c.GetId());
        quest.AddPath(c.GetId(), d.GetId());
        quest.AddPath(d.GetId(), e.GetId());

        quest.BFS(a.GetId());

        //create steps
        //create checkMarkBox button, we send the above event, and also gets the code that is attache
        //in the button prefab and places it into the newly created checkMarkBox button.
        Checkmark checkMarkBox = createBox(a).GetComponent<Checkmark>();
        A.GetComponent<QuestLocation>().SetUp(this, a, checkMarkBox);
        checkMarkBox = createBox(b).GetComponent<Checkmark>();
        checkMarkBox = createBox(c).GetComponent<Checkmark>();
        checkMarkBox = createBox(d).GetComponent<Checkmark>();
        checkMarkBox = createBox(e).GetComponent<Checkmark>();

        Debug.Log(a.status);



        quest.PrintPath();



        
    }

    GameObject createBox(QuestEvent evnt){

        //instantiate the button
        GameObject box = Instantiate(checkmarkbox);
        box.GetComponent<Checkmark>().SetUp(evnt, background);
        //checks if button's event is the first one, if it is, then it updates it's image and status to current
        if(evnt.order == 1)
        {
            box.GetComponent<Checkmark>().UpdateImage(QuestEvent.EventStatus.current);
            evnt.status = QuestEvent.EventStatus.current;
        }
        return box;
    }

    public void UpdateQuestOnCompletion(QuestEvent e)
    {
        foreach(QuestEvent n in quest.questEvents)
        {
            if(n.order == (e.order + 1))
            {
                //make the next in line event available for completion
                n.UpdateQuestEvent(QuestEvent.EventStatus.current);
            }
        }
    }

    


}

public enum GoalType
{
    kill,
    gather,
    walkTo,
    TalkTo,
}