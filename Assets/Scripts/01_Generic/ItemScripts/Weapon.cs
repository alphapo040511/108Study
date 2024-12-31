using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int damage;
    public float range;

    public override void Use()
    {
        Debug.Log($"{itemName} 사용, {damage}의 데미지을 입혔습니다.");
    }
}
