using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestEvent {

    public enum EventStatus
    {
        wating, //not yet completed but can't be worked on cause there's a prerequisite event
        current, // the one the player should bve trying to achieve
        done // has been achieved
    };

    public string stepTitle;
    public string description;
    public string id;
    public int order = -1;
    public EventStatus status;

    public List<QuestPath> pathlist = new List<QuestPath>();

    public QuestEvent(string n, string d)
    {
        id = Guid.NewGuid().ToString();
        stepTitle = n;
        description = d;
        status = EventStatus.wating;
    }

    public void UpdateQuestEvent(EventStatus stat)
    {
        status = stat;
    }

    public string GetId()
    {
        return id;
    }
}
