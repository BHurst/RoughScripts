using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentInventoryItem : InventoryItem
{
    public EquipmentSlot.SlotType slotType;
    public List<ModifierGroup> mods = new List<ModifierGroup>();
    public UniqueAbility attachedAbility;

    public EquipmentInventoryItem()
    {
        itemID = 0;
        itemName = "DEFAULT_ITEM";
        itemImageLocation = "Items/";
        itemDescription = "A default item placeholder.";
        currentStackSize = 1;
        maxStackSize = 1;
        usable = false;
        usable = false;
        itemType = ItemType.Equipment;
        slotType = EquipmentSlot.SlotType.None;
        dropWeight = 1000;
    }

    public void FillFromSerialized(EquipmentInventoryItem_Serialized eII)
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
        if (!string.IsNullOrEmpty(eII.attachedAbility))
        {
            attachedAbility = (UniqueAbility)Activator.CreateInstance(Type.GetType(eII.attachedAbility));
            attachedAbility.abilityOwner = PlayerCharacterUnit.player.unitID;
            attachedAbility.ownerEntityType = RootEntity.EntityType.Player;
        }
    }
}