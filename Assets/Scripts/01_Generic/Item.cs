using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemIndex;
    public string itemName;
    public string description;
    public Sprite icon;
    public int maxQuantity = 64;
    public int currentQuantity;

    public abstract void Use();
}
