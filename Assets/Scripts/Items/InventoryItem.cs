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
    public bool usable = false;
    public int dropWeight = 1000;
    public Rarity rarity = Rarity.None;

    public InventoryItem Clone()
    {
        return (InventoryItem)MemberwiseClone();
    }

    public virtual bool Use(RootCharacter user)
    {
        return false;
    }

    public Color GetRarityColor()
    {
        switch (rarity)
        {
            case Rarity.None:
                return Color.gray;
            case Rarity.Common:
                return Color.white;
            case Rarity.Uncommon:
                return Color.green;
            case Rarity.Rare:
                return Color.blue;
            case Rarity.Epic:
                return Color.magenta;
            case Rarity.Legendary:
                return Color.red;
            default:
                return Color.white;
        }
    }

    public enum ItemType
    {
        Basic,
        Consumable,
        Ammo,
        Equipment
    }

    public enum Rarity
    {
        None,
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
}