using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemInfo itemInfo;
    public bool destroyItem; //set to true if item is being "picked up" to destroy item

    public void OnPointerEnter()
    {
        GetItemInfo();
    }

    public void OnPointerClick()
    {
        DestroyItem();
    }

    void GetItemInfo()
    {
        Debug.Log(itemInfo.name);
    }

    void DestroyItem()
    {
        if (destroyItem)
            Destroy(gameObject);
    }

}
