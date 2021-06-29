using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDoll
{
    public RootUnit character;
    public List<EquipmentSlot> AllEquipment = new List<EquipmentSlot>();
    public EquipmentSlot head = new EquipmentSlot() { slotName = "Head", hasItem = false, itemInSlot = new InventoryItem() };
    public EquipmentSlot back = new EquipmentSlot() { slotName = "Back", hasItem = false, itemInSlot = new InventoryItem() };
    public EquipmentSlot chest = new EquipmentSlot() { slotName = "Chest", hasItem = false, itemInSlot = new InventoryItem() };
    public EquipmentSlot arms = new EquipmentSlot() { slotName = "Arms", hasItem = false, itemInSlot = new InventoryItem() };
    public EquipmentSlot legs = new EquipmentSlot() { slotName = "Legs", hasItem = false, itemInSlot = new InventoryItem() };
    public EquipmentSlot mainHand = new EquipmentSlot() { slotName = "Main Hand", hasItem = false, itemInSlot = new InventoryItem() };
    public EquipmentSlot offHand = new EquipmentSlot() { slotName = "Off Hand", hasItem = false, itemInSlot = new InventoryItem() };
    public EquipmentSlot neck = new EquipmentSlot() { slotName = "Neck", hasItem = false, itemInSlot = new InventoryItem() };
    public EquipmentSlot leftBracelet = new EquipmentSlot() { slotName = "Left Bracelet", hasItem = false, itemInSlot = new InventoryItem() };
    public EquipmentSlot rightBracelet = new EquipmentSlot() { slotName = "Right Bracelet", hasItem = false, itemInSlot = new InventoryItem() };

    void Start()
    {
        AllEquipment.Add(head);
        AllEquipment.Add(back);
        AllEquipment.Add(chest);
        AllEquipment.Add(arms);
        AllEquipment.Add(legs);
        AllEquipment.Add(mainHand);
        AllEquipment.Add(offHand);
        AllEquipment.Add(neck);
        AllEquipment.Add(leftBracelet);
        AllEquipment.Add(rightBracelet);
    }

    //public void CreateStandardSlots()
    //{
    //    availableSlots.Add(new EquipmentSlot() { slotName = "Head", hasItem = false, itemInSlot = new InventoryItem() });
    //    availableSlots.Add(new EquipmentSlot() { slotName = "Back", hasItem = false, itemInSlot = new InventoryItem() });
    //    availableSlots.Add(new EquipmentSlot() { slotName = "Chest", hasItem = false, itemInSlot = new InventoryItem() });
    //    availableSlots.Add(new EquipmentSlot() { slotName = "Back Legs", hasItem = false, itemInSlot = new InventoryItem() });
    //    availableSlots.Add(new EquipmentSlot() { slotName = "Front Legs", hasItem = false, itemInSlot = new InventoryItem() });
    //    availableSlots.Add(new EquipmentSlot() { slotName = "Main Hand", hasItem = false, itemInSlot = new InventoryItem() });
    //    availableSlots.Add(new EquipmentSlot() { slotName = "Off Hand", hasItem = false, itemInSlot = new InventoryItem() });
    //    availableSlots.Add(new EquipmentSlot() { slotName = "Neck", hasItem = false, itemInSlot = new InventoryItem() });
    //    availableSlots.Add(new EquipmentSlot() { slotName = "Left Bracelet", hasItem = false, itemInSlot = new InventoryItem() });
    //    availableSlots.Add(new EquipmentSlot() { slotName = "Right Bracelet", hasItem = false, itemInSlot = new InventoryItem() });
    //}

    public void DetermineStats()
    {
        character.RefreshStats();
    }

    public void RemoveEquipment(InventoryItem itemToEquip)
    {
        if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Head)
        {
            itemToEquip.slotEquippedIn = "None";
            foreach (ModifierGroup stat in head.itemInSlot.iStats.equipment.statBonuses)
            {
                head.itemInSlot = new InventoryItem();
                head.hasItem = false;
            }
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Back)
        {
            itemToEquip.slotEquippedIn = "None";
            foreach (ModifierGroup stat in back.itemInSlot.iStats.equipment.statBonuses)
            {
                back.itemInSlot = new InventoryItem(); ;
                back.hasItem = false;
            }
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Chest)
        {
            itemToEquip.slotEquippedIn = "None";
            foreach (ModifierGroup stat in chest.itemInSlot.iStats.equipment.statBonuses)
            {
                chest.itemInSlot = new InventoryItem(); ;
                chest.hasItem = false;
            }
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Legs)
        {
            itemToEquip.slotEquippedIn = "None";
            foreach (ModifierGroup stat in legs.itemInSlot.iStats.equipment.statBonuses)
            {
                legs.itemInSlot = new InventoryItem(); ;
                legs.hasItem = false;
            }
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Arms)
        {
            itemToEquip.slotEquippedIn = "None";
            foreach (ModifierGroup stat in arms.itemInSlot.iStats.equipment.statBonuses)
            {
                arms.itemInSlot = new InventoryItem(); ;
                arms.hasItem = false;
            }
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Mainhand)
        {
            itemToEquip.slotEquippedIn = "None";
            foreach (ModifierGroup stat in mainHand.itemInSlot.iStats.equipment.statBonuses)
            {
                mainHand.itemInSlot = new InventoryItem(); ;
                mainHand.hasItem = false;
            }
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Offhand)
        {
            itemToEquip.slotEquippedIn = "None";
            foreach (ModifierGroup stat in offHand.itemInSlot.iStats.equipment.statBonuses)
            {
                offHand.itemInSlot = new InventoryItem(); ;
                offHand.hasItem = false;
            }
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Neck)
        {
            itemToEquip.slotEquippedIn = "None";
            foreach (ModifierGroup stat in neck.itemInSlot.iStats.equipment.statBonuses)
            {
                neck.itemInSlot = new InventoryItem(); ;
                neck.hasItem = false;
            }
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.LeftBracelet)
        {
            itemToEquip.slotEquippedIn = "None";
            foreach (ModifierGroup stat in leftBracelet.itemInSlot.iStats.equipment.statBonuses)
            {
                leftBracelet.itemInSlot = new InventoryItem(); ;
                leftBracelet.hasItem = false;
            }
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.RightBracelet)
        {
            itemToEquip.slotEquippedIn = "None";
            foreach (ModifierGroup stat in rightBracelet.itemInSlot.iStats.equipment.statBonuses)
            {
                rightBracelet.itemInSlot = new InventoryItem(); ;
                rightBracelet.hasItem = false;
            }
        }

        foreach (ModifierGroup stat in itemToEquip.iStats.equipment.statBonuses)
        {
            character.totalStats.DecreaseStat(stat.Stat, stat.Aspect, stat.Method, stat.Value);
        }

        character.attributes.ModifyAttribute("Strength", -itemToEquip.iStats.equipment.attributeBonuses.strengthBonus);
        character.attributes.ModifyAttribute("Agility", -itemToEquip.iStats.equipment.attributeBonuses.agilityBonus);
        character.attributes.ModifyAttribute("Intellect", -itemToEquip.iStats.equipment.attributeBonuses.intellectBonus);
        character.attributes.ModifyAttribute("Wisdom", -itemToEquip.iStats.equipment.attributeBonuses.wisdomBonus);
        character.attributes.ModifyAttribute("Stamina", -itemToEquip.iStats.equipment.attributeBonuses.staminaBonus);
        character.attributes.ModifyAttribute("Willpower", -itemToEquip.iStats.equipment.attributeBonuses.willpowerBonus);
        character.attributes.ModifyAttribute("Skill", -itemToEquip.iStats.equipment.attributeBonuses.skillBonus);

        DetermineWeaponStats();
        character.RefreshStats();
        CharacterInventoryPane.DisplayCharacterInventory();
    }

    public void AddEquipment(InventoryItem itemToEquip)
    {
        if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Head)
        {
            itemToEquip.slotEquippedIn = head.slotName;
            head.itemInSlot = itemToEquip;
            head.hasItem = true;
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Back)
        {
            itemToEquip.slotEquippedIn = back.slotName;
            back.itemInSlot = itemToEquip;
            back.hasItem = true;
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Chest)
        {
            itemToEquip.slotEquippedIn = chest.slotName;
            chest.itemInSlot = itemToEquip;
            chest.hasItem = true;
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Legs)
        {
            itemToEquip.slotEquippedIn = legs.slotName;
            legs.itemInSlot = itemToEquip;
            legs.hasItem = true;
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Arms)
        {
            itemToEquip.slotEquippedIn = arms.slotName;
            arms.itemInSlot = itemToEquip;
            arms.hasItem = true;
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Mainhand)
        {
            itemToEquip.slotEquippedIn = mainHand.slotName;
            mainHand.itemInSlot = itemToEquip;
            mainHand.hasItem = true;
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Offhand)
        {
            itemToEquip.slotEquippedIn = offHand.slotName;
            offHand.itemInSlot = itemToEquip;
            offHand.hasItem = true;
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.Neck)
        {
            itemToEquip.slotEquippedIn = neck.slotName;

            neck.itemInSlot = itemToEquip;
            neck.hasItem = true;
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.LeftBracelet)
        {
            itemToEquip.slotEquippedIn = leftBracelet.slotName;
            leftBracelet.itemInSlot = itemToEquip;
            leftBracelet.hasItem = true;
        }
        else if (itemToEquip.iStats.equipment.fitsInSlot == EquipmentSlotName.RightBracelet)
        {
            itemToEquip.slotEquippedIn = rightBracelet.slotName;
            rightBracelet.itemInSlot = itemToEquip;
            rightBracelet.hasItem = true;
        }

        foreach (ModifierGroup stat in itemToEquip.iStats.equipment.statBonuses)
        {
            character.totalStats.IncreaseStat(stat.Stat, stat.Aspect, stat.Method, stat.Value);
        }

        character.attributes.ModifyAttribute("Strength", itemToEquip.iStats.equipment.attributeBonuses.strengthBonus);
        character.attributes.ModifyAttribute("Agility", itemToEquip.iStats.equipment.attributeBonuses.agilityBonus);
        character.attributes.ModifyAttribute("Intellect", itemToEquip.iStats.equipment.attributeBonuses.intellectBonus);
        character.attributes.ModifyAttribute("Wisdom", itemToEquip.iStats.equipment.attributeBonuses.wisdomBonus);
        character.attributes.ModifyAttribute("Stamina", itemToEquip.iStats.equipment.attributeBonuses.staminaBonus);
        character.attributes.ModifyAttribute("Willpower", itemToEquip.iStats.equipment.attributeBonuses.willpowerBonus);
        character.attributes.ModifyAttribute("Skill", itemToEquip.iStats.equipment.attributeBonuses.skillBonus);

        DetermineWeaponStats();
        character.RefreshStats();
        CharacterInventoryPane.DisplayCharacterInventory();
    }

    public void DetermineWeaponStats()
    {
        float tempSpeed = 0;
        float tempLow = 0;
        float tempHigh = 0;

        if (mainHand.hasItem)
        {
            tempSpeed += mainHand.itemInSlot.iStats.equipment.weaponStats.baseAttackSpeed;
            tempLow += mainHand.itemInSlot.iStats.equipment.weaponStats.baseDamageMin;
            tempHigh += mainHand.itemInSlot.iStats.equipment.weaponStats.baseDamageMax;
        }

        if (offHand.hasItem && offHand.itemInSlot.iStats.equipment.isWeapon)
        {
            tempSpeed += offHand.itemInSlot.iStats.equipment.weaponStats.baseAttackSpeed;
            tempLow += offHand.itemInSlot.iStats.equipment.weaponStats.baseDamageMin;
            tempHigh += offHand.itemInSlot.iStats.equipment.weaponStats.baseDamageMax;
        }

        if (mainHand.hasItem && (offHand.hasItem && offHand.itemInSlot.iStats.equipment.isWeapon))
        {
            tempSpeed /= 2;
            tempLow /= 2;
            tempHigh /= 2;
        }

        if (mainHand.hasItem || (offHand.hasItem && offHand.itemInSlot.iStats.equipment.isWeapon))
        {
            //character.totalStats.AttackSpeed = tempSpeed;
            //character.totalStats.IncreaseStat(Modifier.StatModifiers.AttackDamageMin, tempLow);
            //character.totalStats.IncreaseStat(Modifier.StatModifiers.AttackDamageMax, tempHigh);
        }
        else
        {
            //character.equipmentStats.AttackSpeed = 1;
        }

    }

}