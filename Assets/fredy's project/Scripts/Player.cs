using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int experience = 0;

    public Quest quest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
