using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Open_Quest_Trigger : MonoBehaviour
{
    public GameObject AvaQuestWindow;

    public Quest_Giver questWindow;

    private BoxCollider bc;

    
    private void Awake()
    {
        bc = gameObject.GetComponent<BoxCollider>();
    }

    /*
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Triggered!");
            AvaQuestWindow.SetActive(true);
        }
    }*/

    public void OpenAvaQuestWin()
    {
        bc.enabled = false;
        Debug.Log("Available Quest Window opened");
        AvaQuestWindow.SetActive(true);
        
    }
    

    /*
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AvaQuestWindow.SetActive(false);
        }

    }*/

    public void QuestWindowActive()
    {

        Debug.Log("Triggered");
        AvaQuestWindow.SetActive(false);
        
    }
}
