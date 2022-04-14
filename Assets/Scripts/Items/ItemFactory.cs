﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public static EquipmentInventoryItem CreateEquipment(string ItemName, string ItemType)
    {
        EquipmentInventoryItem equippable = new EquipmentInventoryItem();
        EquipmentSO equipmentSO = Resources.Load<EquipmentSO>(string.Format("Items/Equipment/{0}/{1}/{1}", ItemType, ItemName));
        equippable.itemID = equipmentSO.inventoryItem.itemID;
        equippable.itemName = equipmentSO.inventoryItem.itemName;
        equippable.itemImageLocation = equipmentSO.inventoryItem.itemImageLocation;
        equippable.itemDescription = equipmentSO.inventoryItem.itemDescription;
        equippable.itemType = equipmentSO.inventoryItem.itemType;
        equippable.locusRune = new LocusRune();
        if (equipmentSO.attatchedAbility != null && equipmentSO.attatchedAbility.initialized)
            equippable.attatchedAbility = equipmentSO.attatchedAbility.Clone();

        equippable.fitsInSlot = equipmentSO.fitsInSlot;
        foreach (ModifierGroup mod in equipmentSO.mods)
        {
            equippable.mods.Add(new ModifierGroup() { Stat = mod.Stat, Aspect = mod.Aspect, Method = mod.Method, Value = mod.Value });
        }

        return equippable;
    }

    public static LocusRune CreateRandomLocusRune()
    {
        LocusRune newLocusRune = new LocusRune()
        {
            maxSimpleTalents = UnityEngine.Random.Range(1, 5),
            maxComplexTalents = UnityEngine.Random.Range(0, 2)
        };

        for (int i = 0; i < newLocusRune.maxSimpleTalents; i++)
        {
            SimpleTalent newST = new SimpleTalent();
            newST.modifiers = new List<ModifierGroup>();

            ModifierGroup newMod = new ModifierGroup();
            newMod.Aspect = (ModifierGroup.EAspect)UnityEngine.Random.Range(1, Enum.GetValues(typeof(ModifierGroup.EAspect)).Length);
            newMod.Method = (ModifierGroup.EMethod)UnityEngine.Random.Range(1, Enum.GetValues(typeof(ModifierGroup.EMethod)).Length);
            newMod.Stat = (ModifierGroup.EStat)UnityEngine.Random.Range(1, Enum.GetValues(typeof(ModifierGroup.EStat)).Length);

            //newLocusRune.simpleTalents
        }


        return newLocusRune;
    }
}