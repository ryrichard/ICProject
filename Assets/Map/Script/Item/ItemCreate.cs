using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        Debug.Log(item.name);
    }
}
