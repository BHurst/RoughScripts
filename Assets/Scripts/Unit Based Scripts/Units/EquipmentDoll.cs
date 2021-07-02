using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDoll
{
    public RootUnit character;
    public List<EquipmentSlot> AllEquipment = new List<EquipmentSlot>();
    public EquipmentSlot Back = new EquipmentSlot() { slotName = "Back" };
    public EquipmentSlot Chest = new EquipmentSlot() { slotName = "Chest" };
    public EquipmentSlot Foot = new EquipmentSlot() { slotName = "Foot" };
    public EquipmentSlot ForeArm = new EquipmentSlot() { slotName = "Fore Arm" };
    public EquipmentSlot Hand = new EquipmentSlot() { slotName = "Hand" };
    public EquipmentSlot Head = new EquipmentSlot() { slotName = "Head" };
    public EquipmentSlot Neck = new EquipmentSlot() { slotName = "Neck" };
    public EquipmentSlot Shin = new EquipmentSlot() { slotName = "Shin" };
    public EquipmentSlot Shoulder = new EquipmentSlot() { slotName = "Shoulder" };
    public EquipmentSlot Thigh = new EquipmentSlot() { slotName = "Thigh" };
    public EquipmentSlot UpperArm = new EquipmentSlot() { slotName = "Upper Arm" };
    public EquipmentSlot Waist = new EquipmentSlot() { slotName = "Waist" };

    public EquipmentSlot Hand_Left = new EquipmentSlot() { slotName = "Left Hand" };
    public EquipmentSlot Hand_Right = new EquipmentSlot() { slotName = "Right Hand" };

    public EquipmentDoll()
    {
        AllEquipment.Add(Back);
        AllEquipment.Add(Chest);
        AllEquipment.Add(Foot);
        AllEquipment.Add(ForeArm);
        AllEquipment.Add(Hand);
        AllEquipment.Add(Head);
        AllEquipment.Add(Neck);
        AllEquipment.Add(Shin);
        AllEquipment.Add(Shoulder);
        AllEquipment.Add(Thigh);
        AllEquipment.Add(UpperArm);
        AllEquipment.Add(Waist);

        AllEquipment.Add(Hand_Left);
        AllEquipment.Add(Hand_Right);
    }

    public void DetermineStats()
    {
        character.RefreshStats();
    }

    public void AddEquipment(IEquippable itemToEquip)
    {
        EquipmentSlot equipmentSlot = (EquipmentSlot)this.GetType().GetField(itemToEquip.fitsInSlot.ToString()).GetValue(this);

        foreach (ModifierGroup stat in itemToEquip.mods)
        {
            character.totalStats.IncreaseStat(stat.Stat, stat.Aspect, stat.Method, stat.Value);
        }
        equipmentSlot.itemInSlot = itemToEquip;

        if(itemToEquip is Item_Weapon weapon)
        {

        }

        DetermineWeaponStats();
        character.RefreshStats();
        //CharacterInventoryPane.DisplayCharacterInventory();
    }

    public void RemoveEquipment(EquipmentSlotName equipmentSlotName)
    {
        EquipmentSlot equipmentSlot = (EquipmentSlot)this.GetType().GetField(equipmentSlotName.ToString()).GetValue(this);

        if (equipmentSlot.itemInSlot != null)
        {
            foreach (ModifierGroup stat in equipmentSlot.itemInSlot.mods)
            {
                character.totalStats.DecreaseStat(stat.Stat, stat.Aspect, stat.Method, stat.Value);
            }
            equipmentSlot.itemInSlot = null;
        }

        DetermineWeaponStats();
        character.RefreshStats();
        //CharacterInventoryPane.DisplayCharacterInventory();
    }

    public void DetermineWeaponStats()
    {
        //float tempSpeed = 0;
        //float tempLow = 0;
        //float tempHigh = 0;

        //if (mainHand != null)
        //{
        //    tempSpeed += mainHand.itemInSlot.equipment.weaponStats.baseAttackSpeed;
        //    tempLow += mainHand.itemInSlot.equipment.weaponStats.baseDamageMin;
        //    tempHigh += mainHand.itemInSlot.equipment.weaponStats.baseDamageMax;
        //}

    }

}