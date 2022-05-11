using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaistEquipmentBases : MonoBehaviour
{
    List<EquipmentInventoryItem> WaistItems = new List<EquipmentInventoryItem>();

    EquipmentInventoryItem T1_Waist = new EquipmentInventoryItem();
    EquipmentInventoryItem T2_Waist = new EquipmentInventoryItem();
    EquipmentInventoryItem T3_Waist = new EquipmentInventoryItem();
    EquipmentInventoryItem T4_Waist = new EquipmentInventoryItem();

    public void CreateAll()
    {
        T1_Waist.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Waist;
        T1_Waist.itemName = "T1 Faulds";
        T1_Waist.itemDescription = "T1 Faulds";
        T1_Waist.itemImageLocation = string.Format("Items/Equipment/{0}/BasicFaulds/BasicFaulds", T1_Waist.fitsInSlot);
        T1_Waist.dropWeight = 1000;

        T2_Waist.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Waist;
        T2_Waist.itemName = "T2 Faulds";
        T2_Waist.itemDescription = "T2 Faulds";
        T2_Waist.itemImageLocation = string.Format("Items/Equipment/{0}/BasicFaulds/BasicFaulds", T2_Waist.fitsInSlot);
        T1_Waist.dropWeight = 1000;

        T3_Waist.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Waist;
        T3_Waist.itemName = "T3 Faulds";
        T3_Waist.itemDescription = "T3 Faulds";
        T3_Waist.itemImageLocation = string.Format("Items/Equipment/{0}/BasicFaulds/BasicFaulds", T3_Waist.fitsInSlot);
        T1_Waist.dropWeight = 1000;

        T4_Waist.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Waist;
        T4_Waist.itemName = "T4 Faulds";
        T4_Waist.itemDescription = "T4 Faulds";
        T4_Waist.itemImageLocation = string.Format("Items/Equipment/{0}/BasicFaulds/BasicFaulds", T4_Waist.fitsInSlot);
        T1_Waist.dropWeight = 1000;
    }

    public List<EquipmentInventoryItem> GetWaistItems()
    {
        CreateAll();

        GetSomethingTypeWaists();

        return WaistItems;
    }

    public List<EquipmentInventoryItem> GetSomethingTypeWaists()
    {
        WaistItems.Add(T1_Waist);
        WaistItems.Add(T2_Waist);
        WaistItems.Add(T3_Waist);
        WaistItems.Add(T4_Waist);

        return WaistItems;
    }
}