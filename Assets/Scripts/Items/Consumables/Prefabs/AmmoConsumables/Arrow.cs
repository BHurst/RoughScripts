using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : ConsumableInventoryItem
{
    public Arrow()
    {
        itemID = 2;
        itemName = "Arrow";
        itemDescription = "An Arrow";
        itemType = InventoryItem.ItemType.Ammo;
        stackable = true;
        maxStackSize = 100;
        currentStackSize = 99;
    }
}