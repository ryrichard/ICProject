using UnityEngine;
using UnityEngine.SceneManagement;

//This class checks whether the player has arrived to a location
public class QuestLocationCastle : MonoBehaviour
{
    public static QuestLocationCastle qlc
    {
        private set;
        get;
    }

    public QuestEvent qEvent;
    private Quest_Manger qManager;
    public Checkmark cButton;
    public Player player;

    public string data = null;

    private void Awake()
    {


        if (qlc != null && qlc != this)
        {
            //keeps the position of the object from the scence that we're changing too
            qlc.gameObject.transform.position = this.gameObject.transform.position;
            qlc.data = this.data;

            Destroy(gameObject);
        }
        else
        {
            qlc = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        GameObject.DontDestroyOnLoad(qlc);
        qManager = FindObjectOfType<Quest_Manger>();


    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Village"))
        {
            //qManager = FindObjectOfType<Quest_Manger>();
            player = FindObjectOfType<Player>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        //if this object collides with anything else that is not the player, dont do anything
        if (collision.gameObject.tag != "Player") return;

        //check to see if its the current event
        if (qEvent.status != QuestEvent.EventStatus.current) return;
        else
        {
            //to update these variables in the event manager
            Debug.Log("Location TriggerCastle");
            qEvent.UpdateQuestEvent(QuestEvent.EventStatus.done);
            cButton.UpdateImage(QuestEvent.EventStatus.done);
            qManager.UpdateQuestOnCompletion(qEvent);
        }



    }

    //set up when creating locations
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
        Debug.Log("QuestLocation was destroyed");
    }

}
