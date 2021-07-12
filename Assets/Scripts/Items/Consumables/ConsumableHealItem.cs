using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NightShale", menuName = "ScriptableObjects/Item/Consumable/NightShale")]
public class ConsumableHealItem : Item
{
    public void Reset()
    {
        inventoryItem = new InventoryItem();
        inventoryItem.itemID = 1;
        inventoryItem.itemName = "ConsumableHealItem";
        inventoryItem.itemDescription = "Heals for X.";
        inventoryItem.maxCharges = 1;
        inventoryItem.currentCharges = 1;
        inventoryItem.healAmount = 1;
        inventoryItem.itemType = ItemType.Consumable;
        inventoryItem.usable = true;
    }

    public override bool Use(RootUnit user)
    {
        return inventoryItem.usableItem.Use(user, inventoryItem);
    }

    public override void SetSpecial()
    {
        inventoryItem.usableItem = new ConsumabeHealItemUse();
    }
}