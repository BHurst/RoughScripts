using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    
    public int itemID = 0;
    public string itemName = "DEFAULT_ITEM";
    public string itemImageLocation = "Items/";
    public string itemDescription = "A default item placeholder.";
    public ItemType itemType;
    public bool stackable = false;
    public int currentStackSize = 1;
    public int maxStackSize = 1;
    public int currentCharges = 0;
    public int maxCharges = 0;
    public float healAmount = 0;
    public bool usable = false;
    public int dropWeight = 1000;

    public InventoryItem Clone()
    {
        return (InventoryItem)MemberwiseClone();
    }

    public virtual bool Use(RootUnit user)
    {
        return false;
    }

    public enum ItemType
    {
        Basic,
        Consumable,
        Ammo,
        Equipment
    }
}