using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialog : MonoBehaviour
{
    public QuestEvent qEvent;
    public Quest_Manger qManager;
    public Checkmark cButton;


    private DialogBox dbox;

    

    public static QuestDialog qd
    {
        private set;
        get;
    }

    private void Awake()
    {
        qManager = FindObjectOfType<Quest_Manger>();
        cButton = FindObjectOfType<Checkmark>();
        //dbox = FindObjectOfType<DialogBox>();
        
        if (qd != null && qd != this)
        {
            qd.gameObject.transform.position = this.gameObject.transform.position;
            Destroy(gameObject);
        }
        else
        {
            qd = this;
            DontDestroyOnLoad(gameObject);
        }
           
    }

    private void Start()
    {
        GameObject.DontDestroyOnLoad(qd);

    }

    private void Update()
    {
        //Debug.Log(qEvent.status);
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
        Debug.Log("QuestDialog was destroyed");
    }

    //completes the step when called
    public void DialogEndUpdate()
    {
        Debug.Log("Dialog");
        if (qEvent.status != QuestEvent.EventStatus.current) return;
        else
        {
            Debug.Log("Dialog Function called");
            //to update these variables in the event manager
            qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
            cButton.UpdateImage(QuestEvent.EventStatus.done);
            qManager.UpdateQuestOnCompletion(qEvent);
        }
    }
}
