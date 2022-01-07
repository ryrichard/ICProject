using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFacingPlayer : MonoBehaviour
{
    //DataController dc;
    GameObject player;

    private void Awake()
    {
        player = DataController.player;
    }

    private void Update()
    {
        if(player)
            transform.LookAt(player.transform);
    }
}
