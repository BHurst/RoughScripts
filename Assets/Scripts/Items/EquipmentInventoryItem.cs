using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventoryItem : InventoryItem
{
    public EquipmentSlot.SlotType slotType;
    public List<ModifierGroup> mods = new List<ModifierGroup>();
    public RootAbility attatchedAbility { get; set; }

    float currentUses;
    float maxUses;

    public EquipmentInventoryItem()
    {
        itemID = 0;
        itemName = "DEFAULT_ITEM";
        itemImageLocation = "Items/";
        itemDescription = "A default item placeholder.";
        stackable = false;
        currentStackSize = 1;
        maxStackSize = 1;
        usable = false;
        currentUses = 0;
        maxUses = 0;
        usable = false;
        itemType = ItemType.Equipment;
        slotType = EquipmentSlot.SlotType.None;
        dropWeight = 1000;
    }
}