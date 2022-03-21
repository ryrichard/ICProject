using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    // Start is called before the first frame update
    private QuestItemLetter qil;

    private void Awake()
    {
        qil = FindObjectOfType<QuestItemLetter>();
    }

    public void OnDrop()
    {
        qil.ItemPickUpUpdate();
    }
}
