using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreaftingSlot : MonoBehaviour, IDropHandler
{
    public int SlotID = -1;

    public void OnDrop(PointerEventData eventData)
    {
        ItemIcon item = IconDrag.beginDraggedIcon.GetComponent<ItemIcon>();
        if (transform.childCount <= 0 && SlotID >= 0) // item != Weapon (소재 아이템일 경우만)
        {
            IconDrag.beginDraggedIcon.transform.SetParent(transform);
            IconDrag.beginDraggedIcon.transform.position = transform.position;
            CreaftingTable.Instance.InsertMaterial(item.beginItem, SlotID);
            IconDrag.beginDraggedIcon.GetComponent<ItemIcon>().beginItem.slotID = -1;
        }
    }
}
