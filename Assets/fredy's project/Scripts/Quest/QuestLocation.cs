using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class checks whether the player has arrived to a location
public class QuestLocation : MonoBehaviour
{
    public static QuestLocation ql
    {
        private set;
        get;
    }

    public QuestEvent qEvent;
    public Quest_Manger qManager;
    public Checkmark cButton;

    private void Awake()
    {
        if (ql != null && ql != this)
        {
            Destroy(gameObject);
        }
        else
            ql = this;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Location Trigger");
        //if this object collides with anything else that is not the player, dont do anything
        if (collision.gameObject.tag != "Player") return;


        //check to see if its the current event
        if (qEvent.status != QuestEvent.EventStatus.current) return;
        else
        {
            //to update these variables in the event manager
            qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
            cButton.UpdateImage(QuestEvent.EventStatus.done);
            qManager.UpdateQuestOnCompletion(qEvent);
        }
        

        
    }
    //set up when creating locations
    public void SetUp(Quest_Manger qm, QuestEvent qe, Checkmark ck)
    {
        qManager = qm;
        qEvent = qe;
        cButton = ck;
        //set up link between event and button
        qe.button = cButton;
        
    }
}
