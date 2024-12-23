using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopup : MonoBehaviour
{
    public GameObject itemSlotPrefab;

    public GameObject inventoryPopup;

    void Start()
    {
        
    }

    private void UpdateInventory()
    {
        foreach(Transform obj in inventoryPopup.transform)
        {
            Destroy(obj.gameObject);
        }

        foreach(var item in InventoryManager.instance.weaponInventory.items)
        {
            GameObject temp = Instantiate(itemSlotPrefab, inventoryPopup.transform);
            ItemSlot slot = temp.GetComponent<ItemSlot>();
            slot.AddItem(item);
            InventoryManager.instance.OnItemAdded += slot.OnAddItem;
            InventoryManager.instance.OnItemRemoved += slot.UseItem;
        }

        foreach (var item in InventoryManager.instance.potionInventory.items)
        {
            GameObject temp = Instantiate(itemSlotPrefab, inventoryPopup.transform);
            ItemSlot slot = temp.GetComponent<ItemSlot>();
            slot.AddItem(item);
            InventoryManager.instance.OnItemAdded += slot.OnAddItem;
            InventoryManager.instance.OnItemRemoved += slot.UseItem;
        }
    }

    public void OnClick()
    {
        if(inventoryPopup.activeSelf)
        {
            HideInventory();
        }
        else
        {
            ShowInventory();
        }
    }


    void ShowInventory()
    {
        inventoryPopup.SetActive(true);
        UpdateInventory();
    }

    void HideInventory()
    {
        inventoryPopup.SetActive(false);
    }
}
