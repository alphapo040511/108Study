using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    public int healAmount;

    public override void Use()
    {
        Debug.Log($"{itemName} ���, ü�� {healAmount}ȸ��");
    }
}
