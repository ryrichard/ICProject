using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaking : MonoBehaviour
{
    bool talkingToPlayer = false;
    DialogBox dbox;
    GameObject player;

    // Start is called before the first frame update
    void awake()
    {
        dbox = GameObject.FindGameObjectWithTag("DataController").GetComponent<DialogBox>();
    }

    // Update is called once per frame
    void Update()
    {
        dbox.dialogBox.transform.LookAt(player.transform);
        gameObject.transform.LookAt(player.transform);
    }

    public void TalkingToPlayer(GameObject _player)
    {
        player = _player;
        talkingToPlayer = true;
        dbox.CreateDialogBox(gameObject);
    }

    public void StopTalkingToPlayer()
    {
        talkingToPlayer = false;
    }
}
