using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBox : MonoBehaviour
{
    //some script file needed

    public GameObject dialogBox
    {
        get;
        private set;
    }

    [SerializeField] GameObject prefabDialogBox;
    TextMeshProUGUI tmp;
    float timeForDialogBox = 1.5f;
    float dialogOffSet;

    private void Awake()
    {
        tmp = prefabDialogBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void CreateDialogBox(GameObject obj)
    {
        Vector3 pos = obj.transform.position;
        pos.y += obj.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().bounds.size.y + 0.5f;
        dialogBox = Instantiate(prefabDialogBox, pos, obj.transform.rotation);
    }

    public void DestroyDialogBox()
    {
        ClearText();
        Destroy(dialogBox);
    }

    public void FindDialog()
    {
        //Find dialog somewhere
        LoadText("Test");
    }

    public void LoadText(string text)
    {
        tmp.text = text;
    }

    public void WaitBeforeNextLoad()
    {

    }

    public void ClearText()
    {
        tmp.text = "";
    }
}
