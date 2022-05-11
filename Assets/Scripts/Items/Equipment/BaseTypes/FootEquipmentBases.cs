using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootEquipmentBases : MonoBehaviour
{
    List<EquipmentInventoryItem> FootItems = new List<EquipmentInventoryItem>();

    EquipmentInventoryItem T1_Foot = new EquipmentInventoryItem();
    EquipmentInventoryItem T2_Foot = new EquipmentInventoryItem();
    EquipmentInventoryItem T3_Foot = new EquipmentInventoryItem();
    EquipmentInventoryItem T4_Foot = new EquipmentInventoryItem();

    public void CreateAll()
    {
        T1_Foot.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Foot;
        T1_Foot.itemName = "T1 Sabaton";
        T1_Foot.itemDescription = "T1 Sabaton";
        T1_Foot.itemImageLocation = string.Format("Items/Equipment/{0}/BasicSabaton/BasicSabaton", T1_Foot.fitsInSlot);
        T1_Foot.dropWeight = 1000;

        T2_Foot.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Foot;
        T2_Foot.itemName = "T2 Sabaton";
        T2_Foot.itemDescription = "T2 Sabaton";
        T2_Foot.itemImageLocation = string.Format("Items/Equipment/{0}/BasicSabaton/BasicSabaton", T2_Foot.fitsInSlot);
        T1_Foot.dropWeight = 1000;

        T3_Foot.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Foot;
        T3_Foot.itemName = "T3 Sabaton";
        T3_Foot.itemDescription = "T3 Sabaton";
        T3_Foot.itemImageLocation = string.Format("Items/Equipment/{0}/BasicSabaton/BasicSabaton", T3_Foot.fitsInSlot);
        T1_Foot.dropWeight = 1000;

        T4_Foot.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Foot;
        T4_Foot.itemName = "T4 Sabaton";
        T4_Foot.itemDescription = "T4 Sabaton";
        T4_Foot.itemImageLocation = string.Format("Items/Equipment/{0}/BasicSabaton/BasicSabaton", T4_Foot.fitsInSlot);
        T1_Foot.dropWeight = 1000;
    }

    public List<EquipmentInventoryItem> GetFootItems()
    {
        CreateAll();

        GetSomethingTypeFoots();

        return FootItems;
    }

    public List<EquipmentInventoryItem> GetSomethingTypeFoots()
    {
        FootItems.Add(T1_Foot);
        FootItems.Add(T2_Foot);
        FootItems.Add(T3_Foot);
        FootItems.Add(T4_Foot);

        return FootItems;
    }
}