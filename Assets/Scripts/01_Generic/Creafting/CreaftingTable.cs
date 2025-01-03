using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CreaftingTable : MonoBehaviour
{
    public static CreaftingTable Instance;
    public TextMeshProUGUI craftedItemText;                 //원래는 이미지인데 이름으로 대체
    public Transform[] slots = new Transform[2];

    public Item[] materials = new Item[2];

    private Item craftedItem;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject creaftingPopup;


    public void InsertMaterial(Item item, int slot)
    {
        materials[slot] = item;
        RecipeCheck();
    }

    public void RemoveMaterial()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].childCount == 0)
            {
                materials[i] = null;
            }
        }
    }

    private void RecipeCheck()
    {
        foreach(CreaftingRecipe recipe in RecipeList.recipes)
        {
            Item material0 = ItemDatabase.instance.itemList[recipe.materials[0]];
            Item material1 = ItemDatabase.instance.itemList[recipe.materials[1]];
            if (materials.Contains(material0) && materials.Contains(material1))
            {
                craftedItem = ItemDatabase.instance.itemList[recipe.craftedItem];
                craftedItemText.text = craftedItem.itemName;
                return;
            }
            else
            {
                craftedItem = null;
                craftedItemText.text = "결과물";
            }
        }
    }

    public void DoCraft()
    {
        if(craftedItem != null)
        {
            foreach(Item item in materials)
            {
                item.currentQuantity--;
            }
            InventoryManager.instance.AddItem(craftedItem);
        }
    }

    public void OnClick()
    {
        if (creaftingPopup.activeSelf)
        {
            HideCreaftingTable();
        }
        else
        {
            ShowCreaftingTable();
        }
    }

    void ShowCreaftingTable()
    {
        creaftingPopup.SetActive(true);
    }

    void HideCreaftingTable()
    {
        creaftingPopup.SetActive(false);
    
    }
}
