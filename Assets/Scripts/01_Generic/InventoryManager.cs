using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }

    public Inventory<Weapon> weaponInventory;
    public Inventory<Potion> potionInventory;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        weaponInventory = new Inventory<Weapon>();
        potionInventory = new Inventory<Potion>();
        TestItem();
    }

    private void TestItem()
    {
        weaponInventory.AddItem((Weapon)ItemDatabase.instance.itemList["WEAPON_001"], 1);
        potionInventory.AddItem((Potion)ItemDatabase.instance.itemList["POTION_001"], 3);
        potionInventory.AddItem((Potion)ItemDatabase.instance.itemList["POTION_002"], 2);
        potionInventory.AddItem((Potion)ItemDatabase.instance.itemList["POTION_003"], 1);
    }

    public void PotionAdd()
    {
        potionInventory.AddItem((Potion)ItemDatabase.instance.itemList["POTION_001"], 10);
    }

    public void PotionRemove()
    {
        potionInventory.RemoveItem((Potion)ItemDatabase.instance.itemList["POTION_001"], 1);
    }

    public void CheckInventory()
    {
        List<Weapon> weaponList = weaponInventory.FindAllItem(item => item.itemIndex != "");
        Debug.Log("-----���� �κ��丮-----");
        foreach(Weapon weapon in weaponList)
        {
            Debug.Log($"{weapon.itemName} : {weapon.currentQuantity}�� ������");
        }
        Debug.Log("-----------------------");

        List<Potion> potionList= potionInventory.FindAllItem(item => item.itemIndex != "");
        Debug.Log("-----���� �κ��丮-----");
        foreach (Potion potion in potionList)
        {
            Debug.Log($"{potion.itemName} : {potion.currentQuantity}�� ������");
        }
        Debug.Log("-----------------------");
    }


    //������ ���� �ҷ����� �߰�??
}
