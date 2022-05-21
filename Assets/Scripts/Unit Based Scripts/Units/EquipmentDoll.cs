﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDoll
{
    public RootCharacter character;
    public List<EquipmentSlot> AllEquipment = new List<EquipmentSlot>();
    public EquipmentSlot Back_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Back, slotType = EquipmentSlot.SlotType.Back, itemInSlot = null };
    public EquipmentSlot Chest_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Chest, slotType = EquipmentSlot.SlotType.Chest, itemInSlot = null };
    public EquipmentSlot Head_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Head, slotType = EquipmentSlot.SlotType.Head, itemInSlot = null };
    public EquipmentSlot Neck_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Neck, slotType = EquipmentSlot.SlotType.Neck, itemInSlot = null };
    public EquipmentSlot Waist_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Waist, slotType = EquipmentSlot.SlotType.Waist, itemInSlot = null };
    public EquipmentSlot Left_Arm_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Left_Arm, slotType = EquipmentSlot.SlotType.Arm, itemInSlot = null };
    public EquipmentSlot Right_Arm_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Right_Arm, slotType = EquipmentSlot.SlotType.Arm, itemInSlot = null };
    public EquipmentSlot Left_Foot_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Left_Foot, slotType = EquipmentSlot.SlotType.Foot, itemInSlot = null };
    public EquipmentSlot Right_Foot_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Right_Foot, slotType = EquipmentSlot.SlotType.Foot, itemInSlot = null };
    public EquipmentSlot Left_Hand_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Left_Hand, slotType = EquipmentSlot.SlotType.Hand, itemInSlot = null };
    public EquipmentSlot Right_Hand_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Right_Hand, slotType = EquipmentSlot.SlotType.Hand, itemInSlot = null };
    public EquipmentSlot Left_Leg_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Left_Leg, slotType = EquipmentSlot.SlotType.Leg, itemInSlot = null };
    public EquipmentSlot Right_Leg_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Right_Leg, slotType = EquipmentSlot.SlotType.Leg, itemInSlot = null };
    public EquipmentSlot Left_Shoulder_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Left_Shoulder, slotType = EquipmentSlot.SlotType.Shoulder, itemInSlot = null };
    public EquipmentSlot Right_Shoulder_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Right_Shoulder, slotType = EquipmentSlot.SlotType.Shoulder, itemInSlot = null };
    public EquipmentSlot Left_Weapon_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Left_Weapon, slotType = EquipmentSlot.SlotType.Weapon, itemInSlot = null };
    public EquipmentSlot Right_Weapon_Slot = new EquipmentSlot() { slotName = EquipmentSlot.SlotName.Right_Weapon, slotType = EquipmentSlot.SlotType.Weapon, itemInSlot = null };

    public EquipmentDoll()
    {
        AllEquipment.Add(Back_Slot);
        AllEquipment.Add(Chest_Slot);
        AllEquipment.Add(Head_Slot);
        AllEquipment.Add(Neck_Slot);
        AllEquipment.Add(Waist_Slot);
        AllEquipment.Add(Left_Arm_Slot);
        AllEquipment.Add(Right_Arm_Slot);
        AllEquipment.Add(Left_Foot_Slot);
        AllEquipment.Add(Right_Foot_Slot);
        AllEquipment.Add(Left_Hand_Slot);
        AllEquipment.Add(Right_Hand_Slot);
        AllEquipment.Add(Left_Leg_Slot);
        AllEquipment.Add(Right_Leg_Slot);
        AllEquipment.Add(Left_Shoulder_Slot);
        AllEquipment.Add(Right_Shoulder_Slot);
        AllEquipment.Add(Left_Weapon_Slot);
        AllEquipment.Add(Right_Weapon_Slot);
    }

    public void AddEquipment(EquipmentInventoryItem itemToEquip)
    {
        if (itemToEquip.slotType == EquipmentSlot.SlotType.Arm)
        {
            if (Left_Arm_Slot.itemInSlot != null)
            {
                if (Right_Arm_Slot.itemInSlot != null)
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Arm);

                Right_Arm_Slot.itemInSlot = itemToEquip;
                Right_Arm_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
            else
            {
                Left_Arm_Slot.itemInSlot = itemToEquip;
                Left_Arm_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Foot)
        {
            if (Left_Foot_Slot.itemInSlot != null)
            {
                if (Right_Foot_Slot.itemInSlot != null)
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Foot);

                Right_Foot_Slot.itemInSlot = itemToEquip;
                Right_Foot_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
            else
            {
                Left_Foot_Slot.itemInSlot = itemToEquip;
                Left_Foot_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Hand)
        {
            if (Left_Hand_Slot.itemInSlot != null)
            {
                if (Right_Hand_Slot.itemInSlot != null)
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Hand);

                Right_Hand_Slot.itemInSlot = itemToEquip;
                Right_Hand_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
            else
            {
                Left_Hand_Slot.itemInSlot = itemToEquip;
                Left_Hand_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Shoulder)
        {
            if (Left_Shoulder_Slot.itemInSlot != null)
            {
                if (Right_Shoulder_Slot.itemInSlot != null)
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Shoulder);

                Right_Shoulder_Slot.itemInSlot = itemToEquip;
                Right_Shoulder_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
            else
            {
                Left_Shoulder_Slot.itemInSlot = itemToEquip;
                Left_Shoulder_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Leg)
        {
            if (Left_Leg_Slot.itemInSlot != null)
            {
                if (Right_Leg_Slot.itemInSlot != null)
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Leg);

                Right_Leg_Slot.itemInSlot = itemToEquip;
                Right_Leg_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
            else
            {
                Left_Leg_Slot.itemInSlot = itemToEquip;
                Left_Leg_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Weapon)
        {
            if (Left_Weapon_Slot.itemInSlot != null)
            {
                if (Right_Weapon_Slot.itemInSlot != null)
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Weapon);

                Right_Weapon_Slot.itemInSlot = itemToEquip;
                Right_Weapon_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
            else
            {
                Left_Weapon_Slot.itemInSlot = itemToEquip;
                Left_Weapon_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Back)
        {
            if (Back_Slot.itemInSlot != null)
            {
                RemoveEquipment(EquipmentSlot.SlotName.Back);
            }
            Back_Slot.itemInSlot = itemToEquip;
            Back_Slot.imageLocation = itemToEquip.itemImageLocation;
            AddEquipmentBonuses(itemToEquip);
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Head)
        {
            if (Head_Slot.itemInSlot != null)
            {
                RemoveEquipment(EquipmentSlot.SlotName.Head);
            }
            Head_Slot.itemInSlot = itemToEquip;
            Head_Slot.imageLocation = itemToEquip.itemImageLocation;
            AddEquipmentBonuses(itemToEquip);
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Chest)
        {
            if (Chest_Slot.itemInSlot != null)
            {
                RemoveEquipment(EquipmentSlot.SlotName.Chest);
            }
            Chest_Slot.itemInSlot = itemToEquip;
            Chest_Slot.imageLocation = itemToEquip.itemImageLocation;
            AddEquipmentBonuses(itemToEquip);
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Neck)
        {
            if (Neck_Slot.itemInSlot != null)
            {
                RemoveEquipment(EquipmentSlot.SlotName.Neck);
            }
            Neck_Slot.itemInSlot = itemToEquip;
            Neck_Slot.imageLocation = itemToEquip.itemImageLocation;
            AddEquipmentBonuses(itemToEquip);
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Waist)
        {
            if (Waist_Slot.itemInSlot != null)
            {
                RemoveEquipment(EquipmentSlot.SlotName.Waist);
            }
            Waist_Slot.itemInSlot = itemToEquip;
            Waist_Slot.imageLocation = itemToEquip.itemImageLocation;
            AddEquipmentBonuses(itemToEquip);
        }
    }

    public void RemoveEquipment(EquipmentSlot.SlotName slot)
    {
        for (int i = 0; i < AllEquipment.Count; i++)
        {
            if (slot == AllEquipment[i].slotName && AllEquipment[i].itemInSlot != null)
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
                GameWorldReferenceClass.GW_Player.charInventory.UnequipToInventory(AllEquipment[i].itemInSlot);
                AllEquipment[i].itemInSlot = null;
                i = AllEquipment.Count;
            }
        }
    }

    void AddEquipmentBonuses(EquipmentInventoryItem itemToEquip)
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

        if (character is PlayerCharacterUnit playerCharacter)
        {
            //playerCharacter.abilityIKnow1 = itemToEquip.attatchedAbility;
        }
    }
}