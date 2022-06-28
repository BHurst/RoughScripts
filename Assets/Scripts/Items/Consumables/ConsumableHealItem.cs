using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableHealItem : ConsumableInventoryItem
{
    public float healAmount = 0;
    public void Reset()
    {
        itemID = 1;
        itemName = "ConsumableHealItem";
        itemDescription = "Heals for X.";
        maxUses = 1;
        currentUses = 1;
        healAmount = 1;
        itemType = InventoryItem.ItemType.Consumable;
        usable = true;
    }

    public override bool Use(RootCharacter user)
    {
        if (currentUses > 0)
        {
            user.InflictHealing(healAmount, false);
            currentUses--;
            if (currentUses <= 0)
                return true;
        }
        return false;
    }
}