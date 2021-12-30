using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Name")]
public class Item: ScriptableObject
{
    public new string name;
    public string description;

    public void Print()
    {
        Debug.Log("Name : " + name
            + "\nDescription: " + description);
    }
}
