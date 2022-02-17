using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Giver : MonoBehaviour
{
    public Quest quest;

    public Player player;
    
    public GameObject questWindow;

    public GameObject questTracker;

    public Text titleText;
    public Text description;
 

    public void OpenQuestWIndow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        description.text = quest.description;
        

    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.QuestIsActive = true;
        //give quest to player
        player.quest = quest;
        questTracker.SetActive(true);

        
    }


}
