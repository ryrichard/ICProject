using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    int inventorySize;

    public int inventorysize
    {
        set { inventorysize = inventorySize; }
        get { return inventorySize; }
    }

    public List<Item> inventory;
}
