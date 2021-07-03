using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDoll
{
    public RootUnit character;
    public List<EquipmentSlot> AllEquipment = new List<EquipmentSlot>();

    public EquipmentDoll()
    {
        AllEquipment.Add(new EquipmentSlot() { slotName = "Lower Left Arm", acceptedItem = "Arm_Lower", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Upper Left Arm", acceptedItem = "Arm_Lower", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Lower Right Arm", acceptedItem = "Arm_Upper", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Upper Right Arm", acceptedItem = "Arm_Upper", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Back", acceptedItem = "Back", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Chest", acceptedItem = "Chest", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Left Foot", acceptedItem = "Foot", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Right Foot", acceptedItem = "Foot", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Left Hand", acceptedItem = "Hand", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Right Hand", acceptedItem = "Hand", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Head", acceptedItem = "Head", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Lower Left Leg", acceptedItem = "Leg_Lower", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Upper Left Leg", acceptedItem = "Leg_Upper", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Lower Right Leg", acceptedItem = "Leg_Lower", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Upper Right Leg", acceptedItem = "Leg_Upper", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Neck", acceptedItem = "Neck", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Left Shoulder", acceptedItem = "Shoulder", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Right Shoulder", acceptedItem = "Shoulder", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Waist", acceptedItem = "Waist", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Left Weapon", acceptedItem = "Weapon", itemInSlot = null });
        AllEquipment.Add(new EquipmentSlot() { slotName = "Right Weapon", acceptedItem = "Weapon", itemInSlot = null });
    }

    public void DetermineStats()
    {
        character.RefreshStats();
    }

    public void AddEquipment(IEquippable itemToEquip)
    {
        for (int i = 0; i < AllEquipment.Count; i++)
        {
            if(itemToEquip.fitsInSlot.name == AllEquipment[i].acceptedItem && AllEquipment[i].itemInSlot == null)
            {
                foreach (ModifierGroup stat in itemToEquip.mods)
                {
                    character.totalStats.IncreaseStat(stat.Stat, stat.Aspect, stat.Method, stat.Value);
                }
                AllEquipment[i].itemInSlot = itemToEquip;
                i = AllEquipment.Count;
            }
        }

        DetermineWeaponStats();
        character.RefreshStats();
        //CharacterInventoryPane.DisplayCharacterInventory();
    }

    public void RemoveEquipment(string equipmentSlotType)
    {
        for (int i = 0; i < AllEquipment.Count; i++)
        {
            if (equipmentSlotType == AllEquipment[i].acceptedItem && AllEquipment[i].itemInSlot == null)
            {
                foreach (ModifierGroup stat in AllEquipment[i].itemInSlot.mods)
                {
                    character.totalStats.IncreaseStat(stat.Stat, stat.Aspect, stat.Method, stat.Value);
                }
                AllEquipment[i].itemInSlot = null;
                i = AllEquipment.Count;
            }
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