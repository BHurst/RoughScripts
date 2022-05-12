using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDoll
{
    public RootCharacter character;
    public List<EquipmentSlot> AllEquipment = new List<EquipmentSlot>();
    public EquipmentSlot Left_Arm_Slot = new EquipmentSlot() { slotName = "LeftArm", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Arm, itemInSlot = null };
    public EquipmentSlot Right_Arm_Slot = new EquipmentSlot() { slotName = "RightArm", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Arm, itemInSlot = null };
    public EquipmentSlot Back_Slot = new EquipmentSlot() { slotName = "Back", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Back, itemInSlot = null };
    public EquipmentSlot Chest_Slot = new EquipmentSlot() { slotName = "Chest", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Chest, itemInSlot = null };
    public EquipmentSlot Left_Foot_Slot = new EquipmentSlot() { slotName = "LeftFoot", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Foot, itemInSlot = null };
    public EquipmentSlot Right_Foot_Slot = new EquipmentSlot() { slotName = "RightFoot", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Foot, itemInSlot = null };
    public EquipmentSlot Left_Hand_Slot = new EquipmentSlot() { slotName = "LeftHand", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Hand, itemInSlot = null };
    public EquipmentSlot Right_Hand_Slot = new EquipmentSlot() { slotName = "RightHand", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Hand, itemInSlot = null };
    public EquipmentSlot Head_Slot = new EquipmentSlot() { slotName = "Head", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Head, itemInSlot = null };
    public EquipmentSlot Left_Leg_Slot = new EquipmentSlot() { slotName = "LeftLeg", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Leg, itemInSlot = null };
    public EquipmentSlot Right_Leg_Slot = new EquipmentSlot() { slotName = "RightLeg", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Leg, itemInSlot = null };
    public EquipmentSlot Neck_Slot = new EquipmentSlot() { slotName = "Neck", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Neck, itemInSlot = null };
    public EquipmentSlot Left_Shoulder_Slot = new EquipmentSlot() { slotName = "LeftShoulder", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Shoulder, itemInSlot = null };
    public EquipmentSlot Right_Shoulder_Slot = new EquipmentSlot() { slotName = "RightShoulder", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Shoulder, itemInSlot = null };
    public EquipmentSlot Waist_Slot = new EquipmentSlot() { slotName = "Waist", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Waist, itemInSlot = null };
    public EquipmentSlot Left_Weapon_Slot = new EquipmentSlot() { slotName = "LeftWeapon", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Weapon, itemInSlot = null };
    public EquipmentSlot Right_Weapon_Slot = new EquipmentSlot() { slotName = "RightWeapon", acceptedItem = EquipmentInventoryItem.EquipmentSlot.Weapon, itemInSlot = null };

    public EquipmentDoll()
    {
        AllEquipment.Add(Left_Arm_Slot);
        AllEquipment.Add(Right_Arm_Slot);
        AllEquipment.Add(Back_Slot);
        AllEquipment.Add(Chest_Slot);
        AllEquipment.Add(Left_Foot_Slot);
        AllEquipment.Add(Right_Foot_Slot);
        AllEquipment.Add(Left_Hand_Slot);
        AllEquipment.Add(Right_Hand_Slot);
        AllEquipment.Add(Head_Slot);
        AllEquipment.Add(Left_Leg_Slot);
        AllEquipment.Add(Right_Leg_Slot);
        AllEquipment.Add(Neck_Slot);
        AllEquipment.Add(Left_Shoulder_Slot);
        AllEquipment.Add(Right_Shoulder_Slot);
        AllEquipment.Add(Waist_Slot);
        AllEquipment.Add(Left_Weapon_Slot);
        AllEquipment.Add(Right_Weapon_Slot);
    }

    public void DetermineStats()
    {
        character.RefreshStats();
    }

    public void AddEquipment(EquipmentInventoryItem itemToEquip)
    {
        for (int i = 0; i < AllEquipment.Count; i++)
        {
            if (AllEquipment[i].itemInSlot != null && AllEquipment[i].acceptedItem == itemToEquip.fitsInSlot)
            {
                GameWorldReferenceClass.GW_Player.charInventory.UnequipToInventory(AllEquipment[i].itemInSlot);
                RemoveEquipment(AllEquipment[i].itemInSlot.fitsInSlot);
            }
            if (itemToEquip.fitsInSlot == AllEquipment[i].acceptedItem && AllEquipment[i].itemInSlot == null)
            {
                foreach (ModifierGroup mod in itemToEquip.mods)
                {
                    character.totalStats.IncreaseStat(mod.Stat, mod.Aspect, mod.Method, mod.Value);
                }
                foreach (SimpleTalent sT in itemToEquip.locusRune.simpleTalents)
                {
                    foreach (ModifierGroup stat in sT.modifiers)
                    {
                        character.totalStats.IncreaseStat(stat.Stat, stat.Aspect, stat.Method, stat.Value);
                    }
                }
                foreach (ComplexTalent sT in itemToEquip.locusRune.complexTalents)
                {
                    sT.ActivateTalent();
                }
                AllEquipment[i].itemInSlot = itemToEquip;
                AllEquipment[i].imageLocation = itemToEquip.itemImageLocation;
                if (character is PlayerCharacterUnit playerCharacter)
                {
                    //playerCharacter.abilityIKnow1 = itemToEquip.attatchedAbility;
                }
                i = AllEquipment.Count;
            }
        }

        DetermineWeaponStats();
        character.RefreshStats();
        //CharacterInventoryPane.DisplayCharacterInventory();
    }

    public void RemoveEquipment(EquipmentInventoryItem.EquipmentSlot equipmentSlotType)
    {
        for (int i = 0; i < AllEquipment.Count; i++)
        {
            if (equipmentSlotType == AllEquipment[i].acceptedItem && AllEquipment[i].itemInSlot != null)
            {
                foreach (ModifierGroup mod in AllEquipment[i].itemInSlot.mods)
                {
                    character.totalStats.DecreaseStat(mod.Stat, mod.Aspect, mod.Method, mod.Value);
                }
                foreach (SimpleTalent sT in AllEquipment[i].itemInSlot.locusRune.simpleTalents)
                {
                    foreach (ModifierGroup stat in sT.modifiers)
                    {
                        character.totalStats.DecreaseStat(stat.Stat, stat.Aspect, stat.Method, stat.Value);
                    }
                }
                foreach (ComplexTalent sT in AllEquipment[i].itemInSlot.locusRune.complexTalents)
                {
                    sT.DeactivateTalent();
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