using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Dictionary<string, Item> itemList = new Dictionary<string, Item>();

    void Start()
    {
        LoadItemData();
    }

    public void LoadItemData()
    {
        Item[] items = Resources.LoadAll<Item>("Items");
        itemList = new Dictionary<string, Item>();
        foreach (Item item in items)
        {
            item.currentQuantity = 0;
            itemList.Add(item.itemIndex, item);
        }
    }
}
