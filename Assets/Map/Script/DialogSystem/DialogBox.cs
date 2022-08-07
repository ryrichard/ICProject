using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

//consider merging this with CreateDialogBox.cs

public class DialogBox : MonoBehaviour
{
    public OpenCastleDoor castleDoor;

    //dialogbox will handle how the dialog box will appear to users. it will require teh script 
    public GameObject dialogBox
    {
        get;
        private set;
    }

    [SerializeField] private TextAsset inkJSONAsset;
    [SerializeField] GameObject prefabDialogBox;
    TextMeshProUGUI tmp;
    float timeForDialogBox = 1.5f;
    float dialogOffSet = 1f;

    private QuestDialog qd;
    private QuestDialogKnight qdk;
    private GameObject wiz, kni;
    //private GameObject kni2;

    public BoxCollider bc;
    

    private void Awake()
    {
        bc = gameObject.GetComponent<BoxCollider>();
        qdk = FindObjectOfType<QuestDialogKnight>();
        qd = FindObjectOfType<QuestDialog>();
        wiz = GameObject.FindGameObjectWithTag("Wizard");
        kni = GameObject.FindGameObjectWithTag("Guard");
        //kni2 = GameObject.FindGameObjectWithTag("Guard2");
    }

    public void CreateDialogBox()
    {
        bc.enabled = false;
        Vector3 pos = gameObject.transform.position;
        pos.y += gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().bounds.size.y + dialogOffSet;
        dialogBox = Instantiate(prefabDialogBox, pos, Quaternion.identity);
        dialogBox.transform.SetParent(gameObject.transform, true);
        dialogBox.GetComponent<CreateDialogBox>().inkJSONAsset = inkJSONAsset;
    }
    
    public void EndOfDialog()
    {
        bc.enabled = true;


        if (this.gameObject == kni)
        {
            qdk.DialogEndUpdateK();

        }else if (this.gameObject == wiz)
        {
            qd.DialogEndUpdate();
        }
        /*else if (this.gameObject == kni2)
        {
            kni2.DialogEndUpdate();
            castleDoor.GetComponent<OpenCastleDoor>().enabled = true;
        }*/
            
    }
    
   
   
}
