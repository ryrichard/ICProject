using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

//consider merging this with CreateDialogBox.cs

public class DialogBox : MonoBehaviour
{
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

    
    BoxCollider bc;

    
    private void Awake()
    {
        bc = gameObject.GetComponent<BoxCollider>();
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
        Debug.Log("End of dialog");
        bc.enabled = true;
    }
}
