using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeList
{
    public static List<CreaftingRecipe> recipes = new List<CreaftingRecipe>()
    {
        new CreaftingRecipe(new string[] {"POTION_001","POTION_002" }, "POTION_003"),
        new CreaftingRecipe(new string[] {"POTION_001","POTION_003" }, "WEAPON_002"),
    };
}
