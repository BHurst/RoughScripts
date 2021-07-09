using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NightShale", menuName = "ScriptableObjects/Item/Consumable/NightShale")]
public class NightShale : Item
{
    
    public void Reset()
    {
        inventoryItem = new InventoryItem();
        inventoryItem.itemID = 1;
        inventoryItem.itemName = "Night Shale";
        inventoryItem.itemDescription = string.Format("Heals for 35.");
        inventoryItem.maxCharges = 5;
        inventoryItem.currentCharges = 5;
        inventoryItem.healAmount = 35;
        inventoryItem.itemType = ItemType.Consumable;
        inventoryItem.usable = true;
    }

    public override bool Use(RootUnit user)
    {
        return inventoryItem.usableItem.Use(user, inventoryItem);
    }

    public override void SetSpecial()
    {
        inventoryItem.usableItem = new NightShaleUse();
    }
}