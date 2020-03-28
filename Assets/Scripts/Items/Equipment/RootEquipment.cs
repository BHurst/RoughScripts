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
    public List<Bonus> statBonuses = new List<Bonus>();
    public EquipmentAttributes attributeBonuses = new EquipmentAttributes();
}