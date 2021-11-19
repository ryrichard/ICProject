using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeadTracking : MonoBehaviour
{
    Vector3 rot;
    Vector3 pos;
    public TextMeshProUGUI tmp;

    // Update is called once per frame
    void Update()
    {
        rot = this.gameObject.transform.eulerAngles;
        pos = this.gameObject.transform.position;

        tmp.text = "Rotation: " + rot.ToString() +
                   "\nPosition: " + pos.ToString();
    }
}
