using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemLetter : MonoBehaviour
{

    public QuestEvent qEvent;
    public Quest_Manger qManager;
    public Checkmark cButton;
    public GameObject letter;

    public Transform obj;

    public static QuestItemLetter qil
    {
        private set;
        get;
    }

    private void Awake()
    {
        qManager = FindObjectOfType<Quest_Manger>();
        cButton = FindObjectOfType<Checkmark>();
        letter = GameObject.FindGameObjectWithTag("Letter");
        if (qil != null && qil != this)
        {
            qil.gameObject.transform.position = this.gameObject.transform.position;
            Destroy(gameObject);
        }
        else
        {
            qil = this;
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
        GameObject.DontDestroyOnLoad(qil);

    }

    private void Update()
    {
        //Debug.Log(qi.qEvent.status);
    }

    void OnDestroy()
    {
        Debug.Log("QuestDialog was destroyed");
    }


    public void ItemPickUpUpdate()
    {
        Debug.Log("ItemPickUp called");

        if (qEvent.status != QuestEvent.EventStatus.current) return;
        else
        {
            Destroy(letter);
            //to update these variables in the event manager
            qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
            cButton.UpdateImage(QuestEvent.EventStatus.done);
            qManager.UpdateQuestOnCompletion(qEvent);
        }
        /*
        Destroy(armor);
        //to update these variables in the event manager
        qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
        cButton.UpdateImage(QuestEvent.EventStatus.done);
        qManager.UpdateQuestOnCompletion(qEvent);*/
    }

    public void pickUpObject()
    {
        GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().freezeRotation = true;
        //GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = obj.transform.position;
        //this.transform.parent = GameObject.Find("Letter").transform;
    }

    public void dropObject()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        ItemPickUpUpdate();
    }

}
