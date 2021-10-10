using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugDisplay : MonoBehaviour
{
    TextMeshPro tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
        tmp.text = "Debug Display";
    }

    void SetText(string s)
    {
        tmp.text = s;
    }

    void DebugText(string debug)
    {
        Debug.Log("(DebugDisplay.cs) " + debug);
    }
}
