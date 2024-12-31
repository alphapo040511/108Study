using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    public Item beginItem;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCount;

    private const float doubleClickThreshold = 0.25f;
    private float lastClickTime = 0;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        InventoryManager.instance.OnItemAdded += OnAddItem;
        InventoryManager.instance.OnItemRemoved += UseItem;
    }

    public void Init(Item item)
    {
        beginItem = item;
        itemName.text = item.itemName;
        itemCount.text = item.currentQuantity.ToString();
    }

    private void OnClick()
    {
        if (Time.time <= lastClickTime + doubleClickThreshold)
        {
            InventoryManager.instance.RemoveItem(beginItem);
            beginItem.Use();
            UseItem();
        }
        else
        {
            lastClickTime = Time.time;
        }
    }

    public void OnAddItem()
    {
        itemCount.text = beginItem.currentQuantity.ToString();
    }

    public void UseItem()
    {
        itemCount.text = beginItem.currentQuantity.ToString();
        if (beginItem.currentQuantity <= 0)
        {
            InventoryManager.instance.OnItemAdded -= OnAddItem;
            InventoryManager.instance.OnItemRemoved -= UseItem;
            Destroy(gameObject);
        }
    }
}
