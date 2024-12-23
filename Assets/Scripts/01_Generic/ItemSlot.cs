using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public bool hasItem = false;
    public Item currentItem;
    public int quantity;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void AddItem(Item item)
    {
        currentItem = item;
    }

    private void OnClick()
    {
        
    }
}
