using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Quest_Manger : MonoBehaviour 
{
    //singleton
    public static Quest_Manger qm
    {
        private set;
        get;
    }

    public ChangeScene cs;

    public Quest quest = new Quest();
    public GameObject background;
    public GameObject checkmarkbox;


    //private Vector3 lastPositionA;

    //Event location objects
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject F;
    public GameObject G;


    //singleton setup
    private void Awake()
    {
        if (qm != null && qm != this)
        {

            Destroy(gameObject);
        }
        else { qm = this; }

       
    }

    void Start()
    {


        //singleton//
        GameObject.DontDestroyOnLoad(qm); //doesn't destroy quest manager when changing scenes


        //find location
        A = GameObject.FindGameObjectWithTag("Village");
        B = GameObject.FindGameObjectWithTag("Wizard");
        C = GameObject.FindGameObjectWithTag("Armor");
        D = GameObject.FindGameObjectWithTag("Guard");
        E = GameObject.FindGameObjectWithTag("Letter");
        F = GameObject.FindGameObjectWithTag("Resources");
        G = GameObject.FindGameObjectWithTag("Castle");

        //create each event
        QuestEvent a = quest.AddQuestEvent("Initial Access", "A small village, seek conversation.",A);
        QuestEvent b = quest.AddQuestEvent("Initial Access", "Speak with wizard.");
        QuestEvent c = quest.AddQuestEvent("Privilage Escalation", "Disguise as authority, find armor.");
        QuestEvent d = quest.AddQuestEvent("Privilage Escalation", "Speak with Guards");
        QuestEvent e = quest.AddQuestEvent("Lateral Movement", "Intercept the delivery, send a letter to cancel delivery.");
        QuestEvent f = quest.AddQuestEvent("Comand and Control", "Gather Resources, build your trojan horse");
        QuestEvent g = quest.AddQuestEvent("Impact", "Enter the castle unnoticed");
        
        //define the paths between the events - e.g. the order they must be completed
        //from --> to
        quest.AddPath(a.GetId(), b.GetId());
        quest.AddPath(b.GetId(), c.GetId());
        quest.AddPath(c.GetId(), d.GetId());
        quest.AddPath(d.GetId(), e.GetId());
        quest.AddPath(e.GetId(), f.GetId());
        quest.AddPath(f.GetId(), g.GetId());

        quest.BFS(a.GetId());

        //create steps
        //create checkMarkBox button, we send the above event, and also gets the code that is attache
        //in the button prefab and places it into the newly created checkMarkBox button.
        Checkmark checkMarkBox = createBox(a).GetComponent<Checkmark>();
        A.GetComponent<QuestLocation>().SetUp(this, a, checkMarkBox);

        checkMarkBox = createBox(b).GetComponent<Checkmark>(); 
        B.GetComponent<QuestDialog>().SetUp(this, b, checkMarkBox);
        
        checkMarkBox = createBox(c).GetComponent<Checkmark>();
        C.GetComponent<QuestItem>().SetUp(this, c, checkMarkBox);
        
        checkMarkBox = createBox(d).GetComponent<Checkmark>();
        D.GetComponent<QuestDialogKnight>().SetUp(this, d, checkMarkBox);

        checkMarkBox = createBox(e).GetComponent<Checkmark>();
        E.GetComponent<QuestItemLetter>().SetUp(this, e, checkMarkBox);

        checkMarkBox = createBox(f).GetComponent<Checkmark>();
        F.GetComponent<QuestItemResources>().SetUp(this, f, checkMarkBox);

        checkMarkBox = createBox(g).GetComponent<Checkmark>();
        G.GetComponent<QuestLocation>().SetUp(this, g, checkMarkBox);
        
      
        Debug.Log(g.status);
        //Debug.Log(b.status);


        quest.PrintPath();

        
    }


    void OnDestroy()
    {
        Debug.Log("Quest Manager was destroyed");
    }

    GameObject createBox(QuestEvent evnt){

        //instantiate the button
        GameObject box = Instantiate(checkmarkbox);
        box.GetComponent<Checkmark>().SetUp(evnt, background);
        //checks if button's event is the first one, if it is, then it updates it's image and status to current
        if(evnt.order == 1)
        {
            box.GetComponent<Checkmark>().UpdateImage(QuestEvent.EventStatus.current);
            evnt.status = QuestEvent.EventStatus.current;
        }
        return box;
    }

    public void UpdateQuestOnCompletion(QuestEvent e)
    {
        foreach(QuestEvent n in quest.questEvents)
        {
            if(n.order == (e.order + 1))
            {
                //make the next in line event available for completion
                n.UpdateQuestEvent(QuestEvent.EventStatus.current);
                Debug.Log(e.status);
            }
        }
    }

  

    


}
