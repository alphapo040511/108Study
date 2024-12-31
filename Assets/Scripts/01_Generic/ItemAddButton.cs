using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddButton : MonoBehaviour
{
    public string targetItem;

    public InventoryManager inventoryManager;

    public void OnClick()
    {
        inventoryManager.AddItem(ItemDatabase.instance.itemList[targetItem]);
    }
}
