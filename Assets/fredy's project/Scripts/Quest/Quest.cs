using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool QuestIsActive;
    //public bool StepIsActive;

    public string title;
    public string description;
    
    //public GameObject checkmark;

   //public Quest_Manger goal;

    public void Quest_Completed()
    {
        QuestIsActive = false;
        Debug.Log(title + " was completed");
    }

    public List<QuestEvent> questEvents = new List<QuestEvent>();
    

    public Quest() {}

    public QuestEvent AddQuestEvent(string n, string d)
    {
        QuestEvent questEvent = new QuestEvent(n, d);
        questEvents.Add(questEvent);
        return questEvent;
    }

    // QuestEvent for location step quest
    public QuestEvent AddQuestEvent(string n, string d, GameObject l)
    {
        QuestEvent questEvent = new QuestEvent(n, d,l);
        questEvents.Add(questEvent);
        return questEvent;
    }

    //will need a different QuestEvent for NPC dialog and object collection//

    public void AddPath(string fromQuestEvent, string toQuestEvent)
    {
        QuestEvent from = FindQuestEvent(fromQuestEvent);
        QuestEvent to = FindQuestEvent(toQuestEvent);

        if(from != null && to != null)
        {
            QuestPath p = new QuestPath(from, to);
            from.pathlist.Add(p);
        }
    }

    
    QuestEvent FindQuestEvent(string id)
    {
        foreach(QuestEvent n in questEvents)
        {
            if (n.GetId() == id)
                return n;
        }
        return null;
    }

    public void BFS (string id,  int orderNumber = 1) //breath_first_search
    {
        //gets id of the starting node
        QuestEvent thisEvent = FindQuestEvent(id);
        thisEvent.order = orderNumber;

        //loop through the event's pathlist. pathlist is all the different events that this particular event can get to.
        foreach(QuestPath e in thisEvent.pathlist)
        {
            if (e.endEvent.order == -1) //for each of the events that have not been numbered
                BFS(e.endEvent.GetId(), orderNumber + 1); //run BFS from that event's position
        }
    }

    //Console check
    public void PrintPath()
    {
        foreach(QuestEvent n in questEvents)
        {
            Debug.Log(n.stepTitle + " " + n.order);
        }
    }
}
