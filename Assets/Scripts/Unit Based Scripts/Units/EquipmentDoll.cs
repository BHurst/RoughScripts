using System;
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
                {
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Arm);
                    UnlearnItemAbility(itemToEquip);
                }

                Right_Arm_Slot.itemInSlot = itemToEquip;
                Right_Arm_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
            else
            {
                Left_Arm_Slot.itemInSlot = itemToEquip;
                Left_Arm_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Foot)
        {
            if (Left_Foot_Slot.itemInSlot != null)
            {
                if (Right_Foot_Slot.itemInSlot != null)
                {
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Foot);
                    UnlearnItemAbility(itemToEquip);
                }

                Right_Foot_Slot.itemInSlot = itemToEquip;
                Right_Foot_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
            else
            {
                Left_Foot_Slot.itemInSlot = itemToEquip;
                Left_Foot_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Hand)
        {
            if (Left_Hand_Slot.itemInSlot != null)
            {
                if (Right_Hand_Slot.itemInSlot != null)
                {
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Hand);
                    UnlearnItemAbility(itemToEquip);
                }

                Right_Hand_Slot.itemInSlot = itemToEquip;
                Right_Hand_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
            else
            {
                Left_Hand_Slot.itemInSlot = itemToEquip;
                Left_Hand_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Shoulder)
        {
            if (Left_Shoulder_Slot.itemInSlot != null)
            {
                if (Right_Shoulder_Slot.itemInSlot != null)
                {
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Shoulder);
                    UnlearnItemAbility(itemToEquip);
                }

                Right_Shoulder_Slot.itemInSlot = itemToEquip;
                Right_Shoulder_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
            else
            {
                Left_Shoulder_Slot.itemInSlot = itemToEquip;
                Left_Shoulder_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Leg)
        {
            if (Left_Leg_Slot.itemInSlot != null)
            {
                if (Right_Leg_Slot.itemInSlot != null)
                {
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Leg);
                    UnlearnItemAbility(itemToEquip);
                }

                Right_Leg_Slot.itemInSlot = itemToEquip;
                Right_Leg_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
            else
            {
                Left_Leg_Slot.itemInSlot = itemToEquip;
                Left_Leg_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Weapon)
        {
            if (Left_Weapon_Slot.itemInSlot != null)
            {
                if (Right_Weapon_Slot.itemInSlot != null)
                {
                    RemoveEquipment(EquipmentSlot.SlotName.Right_Weapon);
                    UnlearnItemAbility(itemToEquip);
                }

                Right_Weapon_Slot.itemInSlot = itemToEquip;
                Right_Weapon_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
            else
            {
                Left_Weapon_Slot.itemInSlot = itemToEquip;
                Left_Weapon_Slot.imageLocation = itemToEquip.itemImageLocation;
                AddEquipmentBonuses(itemToEquip);
                LearnItemAbility(itemToEquip);
            }
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Back)
        {
            if (Back_Slot.itemInSlot != null)
            {
                RemoveEquipment(EquipmentSlot.SlotName.Back);
                UnlearnItemAbility(itemToEquip);
            }
            Back_Slot.itemInSlot = itemToEquip;
            Back_Slot.imageLocation = itemToEquip.itemImageLocation;
            AddEquipmentBonuses(itemToEquip);
            LearnItemAbility(itemToEquip);
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Head)
        {
            if (Head_Slot.itemInSlot != null)
            {
                RemoveEquipment(EquipmentSlot.SlotName.Head);
                UnlearnItemAbility(itemToEquip);
            }
            Head_Slot.itemInSlot = itemToEquip;
            Head_Slot.imageLocation = itemToEquip.itemImageLocation;
            AddEquipmentBonuses(itemToEquip);
            LearnItemAbility(itemToEquip);
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Chest)
        {
            if (Chest_Slot.itemInSlot != null)
            {
                RemoveEquipment(EquipmentSlot.SlotName.Chest);
                UnlearnItemAbility(itemToEquip);
            }
            Chest_Slot.itemInSlot = itemToEquip;
            Chest_Slot.imageLocation = itemToEquip.itemImageLocation;
            AddEquipmentBonuses(itemToEquip);
            LearnItemAbility(itemToEquip);
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Neck)
        {
            if (Neck_Slot.itemInSlot != null)
            {
                RemoveEquipment(EquipmentSlot.SlotName.Neck);
                UnlearnItemAbility(itemToEquip);
            }
            Neck_Slot.itemInSlot = itemToEquip;
            Neck_Slot.imageLocation = itemToEquip.itemImageLocation;
            AddEquipmentBonuses(itemToEquip);
            LearnItemAbility(itemToEquip);
        }
        else if (itemToEquip.slotType == EquipmentSlot.SlotType.Waist)
        {
            if (Waist_Slot.itemInSlot != null)
            {
                RemoveEquipment(EquipmentSlot.SlotName.Waist);
                UnlearnItemAbility(itemToEquip);
            }
            Waist_Slot.itemInSlot = itemToEquip;
            Waist_Slot.imageLocation = itemToEquip.itemImageLocation;
            AddEquipmentBonuses(itemToEquip);
            LearnItemAbility(itemToEquip);
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
                PlayerCharacterUnit.player.charInventory.UnequipToInventory(AllEquipment[i].itemInSlot);
                AllEquipment[i].itemInSlot = null;
                i = AllEquipment.Count;
            }
        }
    }

    public void RemoveAllEquipment()
    {
        foreach (var item in AllEquipment)
        {
            RemoveEquipment(item.slotName);
        }
    }

    void LearnItemAbility(EquipmentInventoryItem itemToEquip)
    {
        if (!RootAbility.NullorUninitialized(itemToEquip.attachedAbility))
        {
            character.knownAbilities.Add(itemToEquip.attachedAbility);
        }
    }

    void UnlearnItemAbility(EquipmentInventoryItem itemToEquip)
    {
        if (!RootAbility.NullorUninitialized(itemToEquip.attachedAbility))
        {
            character.knownAbilities.Remove(itemToEquip.attachedAbility);
            bool another = false;
            foreach (var item in AllEquipment)
            {
                if (item.itemInSlot.attachedAbility == itemToEquip.attachedAbility)
                    another = true;
            }

            if(character is PlayerCharacterUnit && another)
            {
                ((PlayerCharacterUnit)character).playerHotbar.Unlearn(itemToEquip.attachedAbility);
            }
        }
    }

    void AddEquipmentBonuses(EquipmentInventoryItem itemToEquip)
    {
        foreach (ModifierGroup mod in itemToEquip.mods)
        {
            character.totalStats.IncreaseStat(mod.Stat, mod.Aspect, mod.Method, mod.Value);
        }
    }
}