using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }

    public Inventory<Weapon> weaponInventory;
    public Inventory<Potion> potionInventory;

    public System.Action OnItemAdded;
    public System.Action OnItemRemoved;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        weaponInventory = new Inventory<Weapon>();
        potionInventory = new Inventory<Potion>();
    }

    public void AddItem(Item item, int count = 1)
    {
        switch (item)
        {
            case Weapon:
                weaponInventory.AddItem((Weapon)item, count);
                break;
            case Potion:
                potionInventory.AddItem((Potion)item, count);
                break;
        }
    }

    public void RemoveItem(Item item, int count = 1)
    {
        switch(item)
        {
            case Weapon:
                weaponInventory.RemoveItem((Weapon)item, count);
                break;
            case Potion:
                potionInventory.RemoveItem((Potion)item, count);
                break;
        }
    }


    public void SaveInventory()
    {
        StartCoroutine(ItemToItemData());
    }

    private IEnumerator ItemToItemData()
    {
        List<ItemData> items = new List<ItemData>();

        foreach (Item item in weaponInventory.items)
        {
            ItemData data = new ItemData();
            data.itemIndex = item.itemIndex;
            data.currentQuantity = item.currentQuantity;
            data.slotID = item.slotID;
            items.Add(data);
            yield return null;
        }

        foreach (Item item in potionInventory.items)
        {
            ItemData data = new ItemData();
            data.itemIndex = item.itemIndex;
            data.currentQuantity = item.currentQuantity;
            data.slotID = item.slotID;
            items.Add(data);
            yield return null;
        }

        SaveToJson(items);
    }

    private void SaveToJson(List<ItemData> dataList)
    {
        ItemDataList temp = new ItemDataList();
        temp.items = dataList;
        string jsonData = JsonUtility.ToJson(temp);
        System.IO.File.WriteAllText(Application.dataPath + "/inventory.json", jsonData);
        Debug.Log("저장 완료");
    }

    public void LoadInventory()
    {
        string path = Application.dataPath + "/inventory.json";

        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            ItemDataList dataList = JsonUtility.FromJson<ItemDataList>(json);
            StartCoroutine(ItemDataToItem(dataList.items));
        }
    }

    private IEnumerator ItemDataToItem(List<ItemData> dataList)
    {
        ItemDatabase.instance.LoadItemData();

        foreach (ItemData item in dataList)
        {
            Item targetItem = ItemDatabase.instance.itemList[item.itemIndex];
            targetItem.currentQuantity = item.currentQuantity;
            targetItem.slotID = item.slotID;

            AddItem(targetItem, item.currentQuantity);
            yield return null;
        }
    }
}


[System.Serializable]
public class ItemDataList
{
    public List<ItemData> items;
}

[System.Serializable]
public class ItemData
{
    public string itemIndex;
    public int currentQuantity;
    public int slotID;
}
