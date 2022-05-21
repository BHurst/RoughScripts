using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEquipmentBases
{
    List<EquipmentInventoryItem> BackItems = new List<EquipmentInventoryItem>();

    EquipmentInventoryItem T1_Back = new EquipmentInventoryItem();
    EquipmentInventoryItem T2_Back = new EquipmentInventoryItem();
    EquipmentInventoryItem T3_Back = new EquipmentInventoryItem();
    EquipmentInventoryItem T4_Back = new EquipmentInventoryItem();

    public void CreateAll()
    {
        T1_Back.slotType = EquipmentSlot.SlotType.Back;
        T1_Back.itemName = "T1 Cloak";
        T1_Back.itemDescription = "T1 Cloak";
        T1_Back.itemImageLocation = string.Format("Items/Equipment/{0}/BasicCloak/BasicCloak", T1_Back.slotType);
        T1_Back.dropWeight = 1000;

        T2_Back.slotType = EquipmentSlot.SlotType.Back;
        T2_Back.itemName = "T2 Cloak";
        T2_Back.itemDescription = "T2 Cloak";
        T2_Back.itemImageLocation = string.Format("Items/Equipment/{0}/BasicCloak/BasicCloak", T2_Back.slotType);
        T1_Back.dropWeight = 1000;

        T3_Back.slotType = EquipmentSlot.SlotType.Back;
        T3_Back.itemName = "T3 Cloak";
        T3_Back.itemDescription = "T3 Cloak";
        T3_Back.itemImageLocation = string.Format("Items/Equipment/{0}/BasicCloak/BasicCloak", T3_Back.slotType);
        T1_Back.dropWeight = 1000;

        T4_Back.slotType = EquipmentSlot.SlotType.Back;
        T4_Back.itemName = "T4 Cloak";
        T4_Back.itemDescription = "T4 Cloak";
        T4_Back.itemImageLocation = string.Format("Items/Equipment/{0}/BasicCloak/BasicCloak", T4_Back.slotType);
        T1_Back.dropWeight = 1000;
    }

    public List<EquipmentInventoryItem> GetBackItems()
    {
        CreateAll();

        GetSomethingTypeBacks();

        return BackItems;
    }

    public List<EquipmentInventoryItem> GetSomethingTypeBacks()
    {
        BackItems.Add(T1_Back);
        BackItems.Add(T2_Back);
        BackItems.Add(T3_Back);
        BackItems.Add(T4_Back);

        return BackItems;
    }
}