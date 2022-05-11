using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public static EquipmentInventoryItem CreateEquipmentFromSO(string ItemName, string ItemType, EquipmentInventoryItem.EquipmentSlot itemSlot)
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

        equippable.fitsInSlot = itemSlot;
        foreach (ModifierGroup mod in equipmentSO.mods)
        {
            equippable.mods.Add(new ModifierGroup() { Stat = mod.Stat, Aspect = mod.Aspect, Method = mod.Method, Value = mod.Value });
        }

        return equippable;
    }

    public static EquipmentInventoryItem CreateEquipment(string ItemName, EquipmentInventoryItem.EquipmentSlot ItemType)
    {
        EquipmentInventoryItem equippable = new EquipmentInventoryItem();
        equippable.itemID = UnityEngine.Random.Range(0, 1000000);
        equippable.itemName = ItemName;
        equippable.itemImageLocation = string.Format("Items/Equipment/{0}/{1}/{1}", ItemType, ItemName);
        equippable.itemDescription = "Item Description";
        equippable.itemType = InventoryItem.ItemType.Equipment;
        equippable.locusRune = new LocusRune();
        equippable.fitsInSlot = ItemType;

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
        ModifierBaseManager modBase = new ModifierBaseManager();

        equippable.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Hand;
        equippable.itemType = InventoryItem.ItemType.Equipment;

        int quality = UnityEngine.Random.Range(0, 4);

        if (quality == 0)
        {
            List<ModifierGroup> modsToPickAmongst = modBase.GetGeneralModifier(1);
            equippable.mods.AddRange(modBase.SelectModifiers(modsToPickAmongst, 1));
        }
        else if (quality == 1)
        {
            List<ModifierGroup> modsToPickAmongst = modBase.GetGeneralModifier(2);
            equippable.mods.AddRange(modBase.SelectModifiers(modsToPickAmongst, 2));
        }
        else if (quality == 2)
        {
            List<ModifierGroup> modsToPickAmongst = modBase.GetGeneralModifier(3);
            equippable.mods.AddRange(modBase.SelectModifiers(modsToPickAmongst, 3));
        }
        else if (quality == 3)
        {
            List<ModifierGroup> modsToPickAmongst = modBase.GetGeneralModifier(4);
            equippable.mods.AddRange(modBase.SelectModifiers(modsToPickAmongst, 4));
        }

        return equippable;
    }
}