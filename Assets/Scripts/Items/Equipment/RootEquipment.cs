using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RootEquipment {
    public string equipmentName = "None";
    public EquipmentSlotName fitsInSlot = EquipmentSlotName.None;
    public string type = "None";
    public bool isWeapon = false;
    public WeaponStats weaponStats = new WeaponStats();
    public List<ModifierGroup> statBonuses = new List<ModifierGroup>();
    public EquipmentAttributes attributeBonuses = new EquipmentAttributes();
}