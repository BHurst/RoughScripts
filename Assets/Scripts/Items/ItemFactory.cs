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

        equippable.fitsInSlot = equipmentSO.fitsInSlot;
        foreach(ModifierGroup mod in equipmentSO.mods)
        {
            equippable.mods.Add(new ModifierGroup() { Stat = mod.Stat, Aspect = mod.Aspect, Method = mod.Method, Value = mod.Value });
        }

        return equippable;
    }
}