using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int SlotID;

    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount <= 0)
        {
            IconDrag.beginDraggedIcon.transform.SetParent(transform);
            IconDrag.beginDraggedIcon.transform.position = transform.position;
            IconDrag.beginDraggedIcon.GetComponent<ItemIcon>().beginItem.slotID = SlotID;
        }
    }
}
