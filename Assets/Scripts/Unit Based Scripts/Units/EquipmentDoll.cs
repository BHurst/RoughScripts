using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDoll
{
    public RootUnit character;
    public List<EquipmentSlot> AllEquipment = new List<EquipmentSlot>();
    public EquipmentSlot Lower_Left_Arm_Slot = new EquipmentSlot() { slotName = "Lower Left Arm", acceptedItem = "Arm_Lower", itemInSlot = null };
    public EquipmentSlot Upper_Left_Arm_Slot = new EquipmentSlot() { slotName = "Upper Left Arm", acceptedItem = "Arm_Upper", itemInSlot = null };
    public EquipmentSlot Lower_Right_Arm_Slot = new EquipmentSlot() { slotName = "Lower Right Arm", acceptedItem = "Arm_Lower", itemInSlot = null };
    public EquipmentSlot Upper_Right_Arm_Slot = new EquipmentSlot() { slotName = "Upper Right Arm", acceptedItem = "Arm_Upper", itemInSlot = null };
    public EquipmentSlot Back_Slot = new EquipmentSlot() { slotName = "Back", acceptedItem = "Back", itemInSlot = null };
    public EquipmentSlot Chest_Slot = new EquipmentSlot() { slotName = "Chest", acceptedItem = "Chest", itemInSlot = null };
    public EquipmentSlot Left_Foot_Slot = new EquipmentSlot() { slotName = "Left Foot", acceptedItem = "Foot", itemInSlot = null };
    public EquipmentSlot Right_Foot_Slot = new EquipmentSlot() { slotName = "Right Foot", acceptedItem = "Foot", itemInSlot = null };
    public EquipmentSlot Left_Hand_Slot = new EquipmentSlot() { slotName = "Left Hand", acceptedItem = "Hand", itemInSlot = null };
    public EquipmentSlot Right_Hand_Slot = new EquipmentSlot() { slotName = "Right Hand", acceptedItem = "Hand", itemInSlot = null };
    public EquipmentSlot Head_Slot = new EquipmentSlot() { slotName = "Head", acceptedItem = "Head", itemInSlot = null };
    public EquipmentSlot Lower_Left_Leg_Slot = new EquipmentSlot() { slotName = "Lower Left Leg", acceptedItem = "Leg_Lower", itemInSlot = null };
    public EquipmentSlot Upper_Left_Leg_Slot = new EquipmentSlot() { slotName = "Upper Left Leg", acceptedItem = "Leg_Upper", itemInSlot = null };
    public EquipmentSlot Lower_Right_Leg_Slot = new EquipmentSlot() { slotName = "Lower Right Leg", acceptedItem = "Leg_Lower", itemInSlot = null };
    public EquipmentSlot Upper_Right_Leg_Slot = new EquipmentSlot() { slotName = "Upper Right Leg", acceptedItem = "Leg_Upper", itemInSlot = null };
    public EquipmentSlot Neck_Slot = new EquipmentSlot() { slotName = "Neck", acceptedItem = "Neck", itemInSlot = null };
    public EquipmentSlot Left_Shoulder_Slot = new EquipmentSlot() { slotName = "Left Shoulder", acceptedItem = "Shoulder", itemInSlot = null };
    public EquipmentSlot Right_Shoulder_Slot = new EquipmentSlot() { slotName = "Right Shoulder", acceptedItem = "Shoulder", itemInSlot = null };
    public EquipmentSlot Waist_Slot = new EquipmentSlot() { slotName = "Waist", acceptedItem = "Waist", itemInSlot = null };
    public EquipmentSlot Left_Weapon_Slot = new EquipmentSlot() { slotName = "Left Weapon", acceptedItem = "Weapon", itemInSlot = null };
    public EquipmentSlot Right_Weapon_Slot = new EquipmentSlot() { slotName = "Right Weapon", acceptedItem = "Weapon", itemInSlot = null };

    public EquipmentDoll()
    {
        AllEquipment.Add(Lower_Left_Arm_Slot);
        AllEquipment.Add(Upper_Left_Arm_Slot);
        AllEquipment.Add(Lower_Right_Arm_Slot);
        AllEquipment.Add(Upper_Right_Arm_Slot);
        AllEquipment.Add(Back_Slot);
        AllEquipment.Add(Chest_Slot);
        AllEquipment.Add(Left_Foot_Slot);
        AllEquipment.Add(Right_Foot_Slot);
        AllEquipment.Add(Left_Hand_Slot);
        AllEquipment.Add(Right_Hand_Slot);
        AllEquipment.Add(Head_Slot);
        AllEquipment.Add(Lower_Left_Leg_Slot);
        AllEquipment.Add(Upper_Left_Leg_Slot);
        AllEquipment.Add(Lower_Right_Leg_Slot);
        AllEquipment.Add(Upper_Right_Leg_Slot);
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
            if (itemToEquip.fitsInSlot.name == AllEquipment[i].acceptedItem && AllEquipment[i].itemInSlot == null)
            {
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
                    playerCharacter.abilityIKnow1 = itemToEquip.attatchedAbility;
                }
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