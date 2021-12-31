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
    float dialogOffSet = 1f;

    public void CreateDialogBox()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y += gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().bounds.size.y + dialogOffSet;
        dialogBox = Instantiate(prefabDialogBox, pos, Quaternion.identity);
    }

    public void DestroyDialogBox()
    {
        Destroy(dialogBox);
    }
}
