using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public QuestEvent qEvent;
    public Quest_Manger qManager;
    public Checkmark cButton;
    public GameObject armor;

    public void ItemPickUp()
    {
        if (qEvent.status != QuestEvent.EventStatus.current) return;
        else if(armor.gameObject == null)
        {
            //to update these variables in the event manager
            qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
            cButton.UpdateImage(QuestEvent.EventStatus.done);
            qManager.UpdateQuestOnCompletion(qEvent);
        }
    }
}
