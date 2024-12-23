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

    private void LoadItemData()
    {
        Item[] items = Resources.LoadAll<Item>("Items");

        foreach (Item item in items)
        {
            itemList.Add(item.itemIndex, item);
        }
    }
}
