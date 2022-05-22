using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    //public static EquipmentInventoryItem CreateEquipmentFromSO(string ItemName, string ItemType, EquipmentInventoryItem.EquipmentSlot itemSlot)
    //{
    //    EquipmentInventoryItem equippable = new EquipmentInventoryItem();
    //    EquipmentSO equipmentSO = Resources.Load<EquipmentSO>(string.Format("Items/Equipment/{0}/{1}/{1}", ItemType, ItemName));
    //    equippable.itemID = equipmentSO.inventoryItem.itemID;
    //    equippable.itemName = equipmentSO.inventoryItem.itemName;
    //    equippable.itemImageLocation = equipmentSO.inventoryItem.itemImageLocation;
    //    equippable.itemDescription = equipmentSO.inventoryItem.itemDescription;
    //    equippable.itemType = equipmentSO.inventoryItem.itemType;
    //    equippable.locusRune = new LocusRune();
    //    if (equipmentSO.attatchedAbility != null && equipmentSO.attatchedAbility.initialized)
    //        equippable.attatchedAbility = equipmentSO.attatchedAbility.Clone();

    //    equippable.fitsInSlot = itemSlot;
    //    foreach (ModifierGroup mod in equipmentSO.mods)
    //    {
    //        equippable.mods.Add(new ModifierGroup() { Stat = mod.Stat, Aspect = mod.Aspect, Method = mod.Method, Value = mod.Value });
    //    }

    //    return equippable;
    //}

    public static ModifierBaseManager modBase = new ModifierBaseManager();

    public static EquipmentInventoryItem CreateEquipment(string ItemName, EquipmentSlot.SlotType ItemType)
    {
        EquipmentInventoryItem equippable = new EquipmentInventoryItem();
        equippable.itemID = UnityEngine.Random.Range(0, 1000000);
        equippable.itemName = ItemName;
        equippable.itemImageLocation = string.Format("Items/Equipment/{0}/{1}/{1}", ItemType, ItemName);
        equippable.itemDescription = "Item Description";
        equippable.itemType = InventoryItem.ItemType.Equipment;
        equippable.locusRune = new LocusRune();
        equippable.slotType = ItemType;

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

    public static EquipmentInventoryItem CreateRandomEquipment()
    {
        EquipmentBaseTypeManager equipmentBaseTypeManager = new EquipmentBaseTypeManager();
        EquipmentInventoryItem equippable = equipmentBaseTypeManager.SelectBaseType(equipmentBaseTypeManager.GetAllBaseTypes());
        

        equippable.itemType = InventoryItem.ItemType.Equipment;

        int quality = UnityEngine.Random.Range(0, 6);

        if (quality == 0)
        {
            equippable.mods.AddRange(modBase.SelectRandomModifiers(modBase.GetModifiersBySlot(equippable.slotType), 1));
            equippable.rarity = InventoryItem.Rarity.None;
        }
        else if (quality == 1)
        {
            equippable.mods.AddRange(modBase.SelectRandomModifiers(modBase.GetModifiersBySlot(equippable.slotType), 2));
            equippable.rarity = InventoryItem.Rarity.Common;
        }
        else if (quality == 2)
        {
            equippable.mods.AddRange(modBase.SelectRandomModifiers(modBase.GetModifiersBySlot(equippable.slotType), 3));
            equippable.rarity = InventoryItem.Rarity.Uncommon;
        }
        else if (quality == 3)
        {
            equippable.mods.AddRange(modBase.SelectRandomModifiers(modBase.GetModifiersBySlot(equippable.slotType), 4));
            equippable.rarity = InventoryItem.Rarity.Rare;
        }
        else if (quality == 4)
        {
            equippable.mods.AddRange(modBase.SelectRandomModifiers(modBase.GetModifiersBySlot(equippable.slotType), 5));
            equippable.rarity = InventoryItem.Rarity.Epic;
        }
        else if (quality == 5)
        {
            equippable.mods.AddRange(modBase.SelectRandomModifiers(modBase.GetModifiersBySlot(equippable.slotType), 6));
            equippable.rarity = InventoryItem.Rarity.Legendary;
        }

        return equippable;
    }
}