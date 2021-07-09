using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Arrow", menuName = "ScriptableObjects/Item/Consumable/Arrow")]
public class Arrow : ScriptableObject
{
    public InventoryItem inventoryItem;

    public Arrow()
    {
        inventoryItem.itemID = 2;
        inventoryItem.itemName = "Arrow";
        inventoryItem.itemDescription = "An Arrow";
        inventoryItem.itemType = ItemType.Ammo;
        inventoryItem.stackable = true;
        inventoryItem.maxStackSize = 100;
        inventoryItem.currentStackSize = 99;
    }
}