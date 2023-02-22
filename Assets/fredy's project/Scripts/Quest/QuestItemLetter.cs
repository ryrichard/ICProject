using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemLetter : MonoBehaviour
{

    public QuestEvent qEvent;
    public Quest_Manger qManager;
    public Checkmark cButton;

    public GameObject letter;
    public GameObject obj;

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
        //Debug.Log(qil.qEvent.status);
        obj = GameObject.FindGameObjectWithTag("Obj");
    }

    void OnDestroy()
    {
        Debug.Log("QuestItemLetter was destroyed");
    }


    public void ItemPickUpUpdate()
    {
        Debug.Log("ItemPickUpLetterUpdate called");
        
        if (qEvent.status != QuestEvent.EventStatus.current) return;
        else
        {
            Debug.Log("INSIDE ItemPickUpLetterUpdate");
            this.transform.parent = null;
            Destroy(letter);
            //to update these variables in the event manager
            qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
            cButton.UpdateImage(QuestEvent.EventStatus.done);
            qManager.UpdateQuestOnCompletion(qEvent);
        }
       
    }

    public void pickUpObject()
    {
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().freezeRotation = true;
        obj.GetComponent<Rigidbody>().isKinematic = true; //makes the rigidbody not be acted upon by forces
        this.transform.position = obj.transform.position;
        this.transform.rotation = obj.transform.rotation;
        this.transform.parent = obj.transform;
        this.GetComponent<Rigidbody>().useGravity = false;
        
    }

}
