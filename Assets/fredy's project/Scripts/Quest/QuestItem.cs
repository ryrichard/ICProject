using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public QuestEvent qEvent;
    public Quest_Manger qManager;
    public Checkmark cButton;
    public GameObject armor;



    public static QuestItem qi
    {
        private set;
        get;
    }

    private void Awake()
    {
        qManager = FindObjectOfType<Quest_Manger>();
        cButton = FindObjectOfType<Checkmark>();
        armor = GameObject.FindGameObjectWithTag("Armor");
        if (qi != null && qi != this)
        {
            qi.gameObject.transform.position = this.gameObject.transform.position;
            Destroy(gameObject);
        }
        else
        {
            qi = this;
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
        GameObject.DontDestroyOnLoad(qi);

    }

    private void Update()
    {
        //Debug.Log(qi.qEvent.status);
    }

    void OnDestroy()
    {
        Debug.Log("QuestItemArmor was destroyed");
    }


    public void ItemPickUp()
    {
        Debug.Log("ArmorPickUp called");
        if (qEvent.status != QuestEvent.EventStatus.current) return;
        else
        {
            Destroy(armor);
            //to update these variables in the event manager
            qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
            cButton.UpdateImage(QuestEvent.EventStatus.done);
            qManager.UpdateQuestOnCompletion(qEvent);
        }
        
    }

    
}
