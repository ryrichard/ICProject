using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogKnight : MonoBehaviour
{
    public QuestEvent qEvent;
    public Quest_Manger qManager;
    public Checkmark cButton;


    public static QuestDialogKnight qdk
    {
        private set;
        get;
    }

    private void Awake()
    {
        //finds required objects
        qManager = FindObjectOfType<Quest_Manger>();
        cButton = FindObjectOfType<Checkmark>();

        if (qdk != null && qdk != this)
        {
            //this gameObject takes the position of the same type of gameObject that was in the scene
            qdk.gameObject.transform.position = this.gameObject.transform.position;
            Destroy(gameObject);
        }
        else
        {
            qdk = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        GameObject.DontDestroyOnLoad(qdk);

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
    public void DialogEndUpdateKnight()
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
