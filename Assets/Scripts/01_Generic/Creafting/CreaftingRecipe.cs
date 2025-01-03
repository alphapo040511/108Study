using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaftingRecipe
{
    public string[] materials;
    public string craftedItem;

    public CreaftingRecipe(string[] materials, string craftedItem)
    {
        this.materials = materials;
        this.craftedItem = craftedItem;
    }
}
