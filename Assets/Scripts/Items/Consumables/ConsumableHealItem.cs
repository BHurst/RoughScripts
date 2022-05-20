using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableHealItem : InventoryItem
{
    public void Reset()
    {
        itemID = 1;
        itemName = "ConsumableHealItem";
        itemDescription = "Heals for X.";
        maxCharges = 1;
        currentCharges = 1;
        healAmount = 1;
        itemType = InventoryItem.ItemType.Consumable;
        usable = true;
    }

    public override bool Use(RootCharacter user)
    {
        if (currentCharges > 0)
        {
            user.totalStats.Health_Current += healAmount;
            Mathf.Clamp(user.totalStats.Health_Current, 0, user.totalStats.Health_Max);
            user.ResolveHeal(healAmount, false);
            currentCharges--;
            if (currentCharges <= 0)
                return true;
        }
        return false;
    }
}