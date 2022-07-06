using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipmentInventoryItem_Serialized
{
    public int itemID;
    public string itemName;
    public string itemImageLocation;
    public string itemDescription;
    public InventoryItem.ItemType itemType;
    public bool usable;
    public InventoryItem.Rarity rarity;
    public EquipmentSlot.SlotType slotType;
    public List<ModifierGroup> mods;
    public string attachedAbility;

    public void FillFromUnserialized(EquipmentInventoryItem eII)
    {
        itemID = eII.itemID;
        itemName = eII.itemName;
        itemImageLocation = eII.itemImageLocation;
        itemDescription = eII.itemDescription;
        itemType = eII.itemType;
        usable = eII.usable;
        rarity = eII.rarity;
        slotType = eII.slotType;
        if (eII.mods.Count > 0)
            mods = eII.mods;
        if (!RootAbility.NullorUninitialized(eII.attachedAbility))
            attachedAbility = eII.attachedAbility.ToString();
    }
}