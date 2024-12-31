using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory<T> : MonoBehaviour where T : Item
{
    private int maxCapacity = 16;
    public List<T> items = new List<T>();

    public bool AddItem(T item, int count)
    {
        if(items.Count >= maxCapacity)
        {
            Debug.Log("인벤토리가 가득 찼습니다.");
            return false;
        }

        T targetItem = FindItem(target => target.itemIndex == item.itemIndex);

        if (targetItem != null)
        {
            targetItem.currentQuantity += count;
            if (targetItem.currentQuantity >= targetItem.maxQuantity)
            {
                Debug.Log("이 아이템은 더 이상 소지할 수 없습니다.");
                targetItem.currentQuantity = targetItem.maxQuantity;
                InventoryManager.instance.OnItemAdded?.Invoke();
                return false;
            }
            else
            {
                InventoryManager.instance.OnItemAdded?.Invoke();
                return true;
            }
        }

         int id = InventoryPopup.Instance.firstSlotID();
             // 여기 나중에 수정
           
        if (id >= 0)
        {
            if (item.slotID < 0)
            {
                item.slotID = id;
            }
            item.currentQuantity = count;
            items.Add(item);
            InventoryManager.instance.OnItemAdded?.Invoke();
            return true;
        }
        else
        {
            InventoryManager.instance.OnItemAdded?.Invoke();
            return false;
        }
    }

    public bool RemoveItem(T item, int count = 1)
    {
        T targetItem = FindItem(target => target.itemIndex == item.itemIndex);

        if (targetItem != null)
        {
            targetItem.currentQuantity -= count;
            InventoryManager.instance.OnItemRemoved?.Invoke();
            if (targetItem.currentQuantity <= 0)
            {
                return RemoveAllItem(item);
            }
            return true;
        }
        return false;
    }

    public bool RemoveAllItem(T item)
    {
        if(items.Remove(item))
        {
            InventoryManager.instance.OnItemRemoved?.Invoke();
            return true;
        }
        return false;
    }

    public T FindItem(System.Predicate<T> predicate)
    {
        return items.Find(predicate);
    }

    public List<T> FindAllItem(System.Predicate<T> predicate)
    {
        return items.FindAll(predicate);
    }

    public int ItemQuantity(T item)
    {
        T targetItem = FindItem(target => target.itemIndex == item.itemIndex);
        if(targetItem != null)
        {
            return targetItem.currentQuantity;
        }

        return -1;
    }
}
