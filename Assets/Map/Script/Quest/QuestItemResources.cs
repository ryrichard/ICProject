using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemResources : MonoBehaviour
{
    public QuestEvent qEvent;
    public Quest_Manger qManager;
    public Checkmark cButton;
    public GameObject resources;



    public static QuestItemResources qir
    {
        private set;
        get;
    }

    private void Awake()
    {
        qManager = FindObjectOfType<Quest_Manger>();
        cButton = FindObjectOfType<Checkmark>();
        resources= GameObject.FindGameObjectWithTag("Resources");
        if (qir != null && qir != this)
        {
            qir.gameObject.transform.position = this.gameObject.transform.position;
            Destroy(gameObject);
        }
        else
        {
            qir = this;
            DontDestroyOnLoad(gameObject);
        }

    }


    public void SetUp(Quest_Manger qm, QuestEvent qe, Checkmark ck)
    {
        qManager = qm;
        qEvent = qe;
        cButton = ck;
        //set up link between event and button
        qe.button = cButton;

    }


    private void Start()
    {
        GameObject.DontDestroyOnLoad(qir);

    }

    private void Update()
    {
        //Debug.Log(qi.qEvent.status);
    }

    void OnDestroy()
    {
        Debug.Log("QuestItemResources was destroyed");
    }


    public void ItemPickUp()
    {
        Debug.Log("Item Resources called");
        if (qEvent.status != QuestEvent.EventStatus.current) return;
        else
        {
            Destroy(resources);
            //to update these variables in the event manager
            qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
            cButton.UpdateImage(QuestEvent.EventStatus.done);
            qManager.UpdateQuestOnCompletion(qEvent);
        }

    }


}
