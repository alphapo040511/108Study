using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int damage;
    public float range;

    public override void Use()
    {
        Debug.Log($"{itemName} ���, {damage}�� �������� �������ϴ�.");
    }
}
