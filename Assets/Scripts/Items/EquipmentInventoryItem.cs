using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventoryItem : InventoryItem
{
    public ScriptableObject fitsInSlot;
    public List<ModifierGroup> mods = new List<ModifierGroup>();
}