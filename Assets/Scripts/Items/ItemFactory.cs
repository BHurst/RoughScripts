using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour {
    
    public static InventoryItem CreateGoreHead()
    {
        InventoryItem RE = new InventoryItem();
        RE.iStats.isEquipment = true;
        RE.iStats.itemName = "GoreHead";
        RE.iStats.equipment.fitsInSlot = EquipmentSlotName.Head;
        RE.iStats.equipment.statBonuses.Add(new Bonus { Name = Modifier.StatModifiers.BonusDamagePercent, mod = 1.1f });
        RE.iStats.equipment.attributeBonuses.strengthBonus = 15;
        RE.iStats.equipment.attributeBonuses.staminaBonus = 10;

        return RE;
    }

    public static InventoryItem CreateDashSword()
    {
        InventoryItem RE = new InventoryItem();
        RE.iStats.isEquipment = true;
        RE.iStats.itemName = "Dash Sword";
        RE.iStats.equipment.fitsInSlot = EquipmentSlotName.Mainhand;
        RE.iStats.equipment.attributeBonuses.agilityBonus = 20;
        RE.iStats.equipment.isWeapon = true;
        RE.iStats.equipment.weaponStats.baseAttackSpeed = 1;
        RE.iStats.equipment.weaponStats.baseDamageMin = 7;
        RE.iStats.equipment.weaponStats.baseDamageMax = 12;
        RE.iStats.equipment.weaponStats.weaponType = WeaponStats.WeaponType.Sword1h;
        RE.iStats.equipment.weaponStats.SetActiveFrames();

        return RE;
    }

    public static InventoryItem CreateWizardRobe()
    {
        InventoryItem RE = new InventoryItem();
        RE.iStats.isEquipment = true;
        RE.iStats.itemName = "Wizard Robe";
        RE.iStats.equipment.fitsInSlot = EquipmentSlotName.Chest;
        RE.iStats.equipment.attributeBonuses.intellectBonus = 20;
        RE.iStats.equipment.attributeBonuses.wisdomBonus = 20;

        return RE;
    }

    public static InventoryItem CreateMindOfMatterAmulet()
    {
        InventoryItem RE = new InventoryItem();
        RE.iStats.isEquipment = true;
        RE.iStats.itemName = "Mind of Matter";
        RE.iStats.equipment.fitsInSlot = EquipmentSlotName.Neck;
        RE.iStats.equipment.attributeBonuses.willpowerBonus = 15;

        return RE;
    }
}