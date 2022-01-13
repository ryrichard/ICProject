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

    public Text step1, step2, step3;
    public Text step1des, step2des, step3des;


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
        quest.QuestIsActive = true;
        //give quest to player
        player.quest = quest;
    }


}
