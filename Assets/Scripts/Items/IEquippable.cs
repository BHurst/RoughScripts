using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquippable
{
    public EquipmentSlotName fitsInSlot { get; set; }
    public List<ModifierGroup> mods { get; set; }
}