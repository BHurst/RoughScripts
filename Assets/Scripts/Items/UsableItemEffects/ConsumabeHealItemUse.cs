using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumabeHealItemUse : IUsable
{
    public bool Use(RootUnit user, InventoryItem inventoryItem)
    {
        if (inventoryItem.currentCharges > 0)
        {
            user.unitHealth += inventoryItem.healAmount;
            Mathf.Clamp(user.unitHealth, 0, user.unitMaxHealth);
            user.ResolveHeal(inventoryItem.healAmount);
            inventoryItem.currentCharges--;
            if (inventoryItem.currentCharges <= 0)
                return true;
        }
        return false;
    }
}