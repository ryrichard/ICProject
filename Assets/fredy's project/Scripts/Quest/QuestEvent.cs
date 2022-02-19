using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestEvent {

    public enum EventStatus
    {
        wating, //not yet completed but can't be worked on cause there's a prerequisite event
        current, // the one the player should be trying to achieve
        done // has been achieved
    };

    public string stepTitle;
    public string description;
    public string id;
    public int order = -1;
    public EventStatus status;
    public Checkmark button;


    // gameobject for location step
    public GameObject location;
    //gameObject for gather step
    public GameObject item;
    //gameObject for TalkTo step
    public GameObject npc;


    public List<QuestPath> pathlist = new List<QuestPath>();

    //default constructor
    public QuestEvent(string n, string d)
    {
        id = Guid.NewGuid().ToString();
        stepTitle = n;
        description = d;
        status = EventStatus.wating;
    }

    //contructor for QuestEvent step that requires a location
    public QuestEvent(string n, string d, GameObject loc)
    {
        id = Guid.NewGuid().ToString();
        stepTitle = n;
        description = d;
        status = EventStatus.wating;
        location = loc;
    }




    public void UpdateQuestEvent(EventStatus stat)
    {
        status = stat;
        button.UpdateImage(stat);
        
    }

    public string GetId()
    {
        return id;
    }
}
