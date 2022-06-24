using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeckEquipmentBases
{
    List<EquipmentInventoryItem> NeckItems = new List<EquipmentInventoryItem>();

    EquipmentInventoryItem T1_Neck = new EquipmentInventoryItem();
    EquipmentInventoryItem T2_Neck = new EquipmentInventoryItem();
    EquipmentInventoryItem T3_Neck = new EquipmentInventoryItem();
    EquipmentInventoryItem T4_Neck = new EquipmentInventoryItem();

    public void CreateAll()
    {
        T1_Neck.slotType = EquipmentSlot.SlotType.Neck;
        T1_Neck.itemName = "T1 Amulet";
        T1_Neck.itemDescription = "T1 Amulet";
        T1_Neck.itemImageLocation = string.Format("Items/Equipment/{0}/BasicAmulet/BasicAmulet", T1_Neck.slotType);
        T1_Neck.dropWeight = 1000;

        T2_Neck.slotType = EquipmentSlot.SlotType.Neck;
        T2_Neck.itemName = "T2 Amulet";
        T2_Neck.itemDescription = "T2 Amulet";
        T2_Neck.itemImageLocation = string.Format("Items/Equipment/{0}/BasicAmulet/BasicAmulet", T2_Neck.slotType);
        T1_Neck.dropWeight = 1000;

        T3_Neck.slotType = EquipmentSlot.SlotType.Neck;
        T3_Neck.itemName = "T3 Amulet";
        T3_Neck.itemDescription = "T3 Amulet";
        T3_Neck.itemImageLocation = string.Format("Items/Equipment/{0}/BasicAmulet/BasicAmulet", T3_Neck.slotType);
        T1_Neck.dropWeight = 1000;

        T4_Neck.slotType = EquipmentSlot.SlotType.Neck;
        T4_Neck.itemName = "T4 Amulet";
        T4_Neck.itemDescription = "T4 Amulet";
        T4_Neck.itemImageLocation = string.Format("Items/Equipment/{0}/BasicAmulet/BasicAmulet", T4_Neck.slotType);
        T1_Neck.dropWeight = 1000;
    }

    public List<EquipmentInventoryItem> GetNeckItems()
    {
        CreateAll();

        GetSomethingTypeNecks();

        return NeckItems;
    }

    public List<EquipmentInventoryItem> GetSomethingTypeNecks()
    {
        NeckItems.Add(T1_Neck);
        NeckItems.Add(T2_Neck);
        NeckItems.Add(T3_Neck);
        NeckItems.Add(T4_Neck);

        return NeckItems;
    }
}