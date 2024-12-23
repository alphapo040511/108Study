using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory<T> : MonoBehaviour where T : Item
{
    private int maxCapacity = 16;
    private List<T> items = new List<T>();

    public bool AddItem(T item, int count = 1)
    {
        if(items.Count >= maxCapacity)
        {
            Debug.Log("�κ��丮�� ���� á���ϴ�.");
            return false;
        }

        T targetItem = FindItem(target => target.itemIndex == item.itemIndex);

        if (targetItem != null)
        {
            targetItem.currentQuantity += count;

            if (targetItem.currentQuantity >= targetItem.maxQuantity)
            {
                Debug.Log("�� �������� �� �̻� ������ �� �����ϴ�.");
                targetItem.currentQuantity = targetItem.maxQuantity;
                return false;
            }
            else
            {
                return true;
            }
        }

        item.currentQuantity = count;
        items.Add(item);
        return true;
    }

    public bool RemoveItem(T item, int count = 1)
    {
        T targetItem = FindItem(target => target.itemIndex == item.itemIndex);

        if (targetItem != null)
        {
            targetItem.currentQuantity -= count;
            if(targetItem.currentQuantity <= 0)
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
