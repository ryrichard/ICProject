using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialog : MonoBehaviour
{
    public QuestEvent qEvent;
    public Quest_Manger qManager;
    public Checkmark cButton;


    public DialogBox dbox;

    public static QuestDialog qd
    {
        private set;
        get;
    }

    private void Awake()
    {
        if (qd != null && qd != this)
        {
            Destroy(gameObject);
        }
        else
            qd = this;
    }

    private void Start()
    {
        GameObject.DontDestroyOnLoad(qd);

    }

    
    public void SetUp(Quest_Manger qm, QuestEvent qe, Checkmark ck)
    {
        qManager = qm;
        qEvent = qe;
        cButton = ck;
        //set up link between event and button
        qe.button = cButton;

    }

    void OnDestroy()
    {
        Debug.Log("Location was destroyed");
    }

    //completes the step when called
    private void DialogEnd()
    {
        if (qEvent.status != QuestEvent.EventStatus.current) return;
        else if(dbox.dialogBox == false)
        {
            //to update these variables in the event manager
            qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
            cButton.UpdateImage(QuestEvent.EventStatus.done);
            qManager.UpdateQuestOnCompletion(qEvent);
        }
    }
}
