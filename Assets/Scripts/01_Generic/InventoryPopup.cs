using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopup : MonoBehaviour
{
    public static InventoryPopup Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject inventoryPopup;
    public GameObject creaftingPopup;
    public GameObject itemIconPrefab;

    public Transform topCanvas;

    void Start()
    {
        UpdateInventory();
        InventoryManager.instance.OnItemAdded += UpdateInventory;
    }

    public void UpdateInventory()
    {
        List<Item> items = new List<Item>();

        items.AddRange(InventoryManager.instance.weaponInventory.items);
        items.AddRange(InventoryManager.instance.potionInventory.items);

        InventorySet(items);
    }


    private void InventorySet(List<Item> items)
    {
        InventoryClear();

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].slotID != -1)
            {
                GameObject temp = Instantiate(itemIconPrefab, inventoryPopup.transform.GetChild(items[i].slotID));
                temp.GetComponent<ItemIcon>().Init(items[i]);
                temp.GetComponent<IconDrag>().onDragParent = topCanvas;
            }
        }
    }

    public int firstSlotID()        //슬롯 생성시 인벤토리 최대 크기에 맞춰 생성 (추가 안함)
    {
        int slotID = 0;
        foreach (Transform obj in inventoryPopup.transform)
        {
            if (obj.childCount <= 0)
            {
                return slotID;
            }
            else
            {
                slotID++;
            }
        }

        return -1;
    }

    public void InventoryClear()
    {
        foreach (Transform obj in inventoryPopup.transform)
        {
            if (obj.childCount > 0)
            {
                Destroy(obj.GetChild(0).gameObject);
            }
        }
    }

}
