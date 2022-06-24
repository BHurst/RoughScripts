using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public static ModifierBaseManager modBase = new ModifierBaseManager(true);

    public static EquipmentInventoryItem CreateEquipment(string ItemName, EquipmentSlot.SlotType ItemType)
    {
        EquipmentInventoryItem equippable = new EquipmentInventoryItem();
        equippable.itemID = UnityEngine.Random.Range(0, 1000000);
        equippable.itemName = ItemName;
        equippable.itemImageLocation = string.Format("Items/Equipment/{0}/{1}/{1}", ItemType, ItemName);
        equippable.itemDescription = "Item Description";
        equippable.itemType = InventoryItem.ItemType.Equipment;
        equippable.slotType = ItemType;

        return equippable;
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