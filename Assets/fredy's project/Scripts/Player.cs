using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int experience = 0;

    public Quest quest;

    public void Gather()
    {
        if (quest.isActive)
        {
            quest.goal.ItemGathered();
            if (quest.goal.isReached())
            {
                experience += quest.experienceReward;
                quest.Quest_Completed();
            }
        }
    }
}
