using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Giver : MonoBehaviour
{
    public Quest quest;

    public Player player;
    
    public GameObject questWindow;

    public Text titleText;
    public Text description;
    public Text experienceText;


    public void OpenQuestWIndow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        description.text = quest.description;
        //experienceText.text = quest.experienceReward.ToString();

    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        //give quest to player
        player.quest = quest;
    }
}
