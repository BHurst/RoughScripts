using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public static Item_Equipment CreateEquipment(string ItemName, string ItemType)
    {
        Item_Equipment equippable = new Item_Equipment();
        EquipmentSO equipmentSO = Resources.Load<EquipmentSO>(string.Format("Items/Equipment/{0}/{1}", ItemType, ItemName));
        equippable.itemID = equipmentSO.itemID;
        equippable.itemName = equipmentSO.itemName;
        equippable.itemImageLocation = equipmentSO.itemImageLocation;
        equippable.itemDescription = equipmentSO.itemDescription;
        equippable.itemType = equipmentSO.itemType;

        equippable.fitsInSlot = equipmentSO.fitsInSlot;
        foreach(ModifierGroup mod in equipmentSO.mods)
        {
            equippable.mods.Add(new ModifierGroup() { Stat = mod.Stat, Aspect = mod.Aspect, Method = mod.Method, Value = mod.Value });
        }

        return equippable;
    }
}