using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Equipment : Item, IEquippable
{
    public EquipmentSlotName fitsInSlot { get; set; }
    public List<ModifierGroup> mods { get; set; } = new List<ModifierGroup>();
}