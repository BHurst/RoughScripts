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
        locusRune = new LocusRune();
        dropWeight = 1000;
    }

    public enum EquipmentSlot
    {
        Any,
        Arm,
        Back,
        Chest,
        Foot,
        Hand,
        Head,
        Leg,
        Neck,
        Shoulder,
        Waist,
        Weapon
    }
}