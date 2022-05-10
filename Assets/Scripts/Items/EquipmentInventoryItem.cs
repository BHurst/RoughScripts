using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventoryItem : InventoryItem
{
    public EquipmentSlot fitsInSlot;
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
        currentCharges = 0;
        maxCharges = 0;
        healAmount = 0;
        usable = false;
        fitsInSlot = EquipmentSlot.Any;
    }

    public enum EquipmentSlot
    {
        Any,
        Lower_Arm_Slot,
        Upper_Arm_Slot,
        Back_Slot,
        Chest_Slot,
        Foot_Slot,
        Hand_Slot,
        Head_Slot,
        Lower_Leg_Slot,
        Upper_Leg_Slot,
        Neck_Slot,
        Shoulder_Slot,
        Waist_Slot,
        Weapon_Slot
    }
}