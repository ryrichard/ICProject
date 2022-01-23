using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDiialog : MonoBehaviour
{
    public QuestEvent qEvent;
    public Quest_Manger qManager;
    public Checkmark cButton;

    private void DialogEnd()
    {
        if (qEvent.status != QuestEvent.EventStatus.current) return;
        else
        {
            //to update these variables in the event manager
            qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
            cButton.UpdateImage(QuestEvent.EventStatus.done);
            qManager.UpdateQuestOnCompletion(qEvent);
        }
    }
}
