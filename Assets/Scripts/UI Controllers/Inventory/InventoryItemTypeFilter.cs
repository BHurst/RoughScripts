using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryItemTypeFilter : MonoBehaviour
{
    public CharacterInventoryPane CharacterInventoryPane;
    public TMP_Dropdown itemTypeDropdown;
    public TMP_Dropdown equipmentTypeDropdown;

    void Start()
    {
        itemTypeDropdown.AddOptions(new List<string>()
        {
            InventoryItem.ItemType.None.ToString(),
            InventoryItem.ItemType.Basic.ToString(),
            InventoryItem.ItemType.Ammo.ToString(),
            InventoryItem.ItemType.Equipment.ToString(),
            InventoryItem.ItemType.Consumable.ToString()
        });

        equipmentTypeDropdown.AddOptions(new List<string>()
        {
            EquipmentSlot.SlotType.None.ToString(),
            EquipmentSlot.SlotType.Back.ToString(),
            EquipmentSlot.SlotType.Chest.ToString(),
            EquipmentSlot.SlotType.Head.ToString(),
            EquipmentSlot.SlotType.Neck.ToString(),
            EquipmentSlot.SlotType.Waist.ToString(),
            EquipmentSlot.SlotType.Arm.ToString(),
            EquipmentSlot.SlotType.Foot.ToString(),
            EquipmentSlot.SlotType.Hand.ToString(),
            EquipmentSlot.SlotType.Leg.ToString(),
            EquipmentSlot.SlotType.Shoulder.ToString(),
            EquipmentSlot.SlotType.Weapon.ToString()
        });
    }

    public void PickType()
    {
        CharacterInventoryPane.FilterInventory((InventoryItem.ItemType)Enum.Parse(typeof(InventoryItem.ItemType), itemTypeDropdown.options[itemTypeDropdown.value].text), (EquipmentSlot.SlotType)Enum.Parse(typeof(EquipmentSlot.SlotType), equipmentTypeDropdown.options[equipmentTypeDropdown.value].text));
    }
}