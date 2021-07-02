using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightShale : Item, IUsable
{
    public int charges { get; set; }
    public int healAmount;

    public NightShale()
    {
        charges = 5;
        healAmount = 35;

        itemID = 1;
        itemName = "Night Shale";
        itemDescription = string.Format("Heals for {0}.", healAmount);
        itemType = ItemType.Consumable;
    }

    public override void Use(RootUnit user)
    {
        if(charges > 0)
        {
            user.unitHealth += healAmount;
            Mathf.Clamp(user.unitHealth, 0, user.unitMaxHealth);
            user.ResolveHeal(healAmount);
            charges--;
        }
    }
}