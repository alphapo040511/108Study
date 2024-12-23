using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item currentItem;
    public int quantity;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCount;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void AddItem(Item item)
    {
        currentItem = item;
        itemName.text = item.itemName;
        itemCount.text = item.currentQuantity.ToString();
    }

    private void OnClick()
    {
        InventoryManager.instance.RemoveItem(currentItem);
        currentItem.Use();
    }

    public void OnAddItem()
    {
        itemCount.text = currentItem.currentQuantity.ToString();
    }

    public void UseItem()
    {
        itemCount.text = currentItem.currentQuantity.ToString();
        if (currentItem.currentQuantity <= 0)
        {
            InventoryManager.instance.OnItemAdded -= OnAddItem;
            InventoryManager.instance.OnItemRemoved -= UseItem;
            Destroy(gameObject);
        }
    }
}
