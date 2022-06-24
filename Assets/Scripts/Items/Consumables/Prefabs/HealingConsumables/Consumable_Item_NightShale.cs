using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable_Item_NightShale : ConsumableHealItem
{
    public Consumable_Item_NightShale()
    {
        itemID = 00001;
        itemName = "NightShale";
        itemDescription = "Heals for 35.";
        maxUses = 2;
        currentUses = 2;
        healAmount = 35;
        itemType = InventoryItem.ItemType.Consumable;
        usable = true;
    }
}