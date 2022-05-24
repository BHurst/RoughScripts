using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventoryItem : InventoryItem
{
    public EquipmentSlot.SlotType slotType;
    public List<ModifierGroup> mods = new List<ModifierGroup>();
    public Ability attatchedAbility { get; set; }
    public LocusRune locusRune;

    public EquipmentInventoryItem()
    {
        itemID = 0;
        itemName = "DEFAULT_ITEM";
        itemImageLocation = "Items/";
        itemDescription = "A default item placeholder.";
        stackable = false;
        currentStackSize = 1;
        maxStackSize = 1;
        currentReserve = 0;
        maxReserve = 0;
        healAmount = 0;
        usable = false;
        slotType = EquipmentSlot.SlotType.Any;
        locusRune = new LocusRune();
        dropWeight = 1000;
    }
}