using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumabeHealItemUse : IUsable
{
    public bool Use(RootUnit user, InventoryItem inventoryItem)
    {
        if (inventoryItem.currentCharges > 0)
        {
            user.totalStats.Health_Current.value += inventoryItem.healAmount;
            Mathf.Clamp(user.totalStats.Health_Current.value, 0, user.totalStats.Health_Max.value);
            user.ResolveHeal(inventoryItem.healAmount);
            inventoryItem.currentCharges--;
            if (inventoryItem.currentCharges <= 0)
                return true;
        }
        return false;
    }
}