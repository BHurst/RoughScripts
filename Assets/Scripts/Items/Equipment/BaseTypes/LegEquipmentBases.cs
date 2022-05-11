using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegEquipmentBases : MonoBehaviour
{
    List<EquipmentInventoryItem> LegItems = new List<EquipmentInventoryItem>();

    EquipmentInventoryItem T1_Leg = new EquipmentInventoryItem();
    EquipmentInventoryItem T2_Leg = new EquipmentInventoryItem();
    EquipmentInventoryItem T3_Leg = new EquipmentInventoryItem();
    EquipmentInventoryItem T4_Leg = new EquipmentInventoryItem();

    public void CreateAll()
    {
        T1_Leg.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Leg;
        T1_Leg.itemName = "T1 Greave";
        T1_Leg.itemDescription = "T1 Greave";
        T1_Leg.itemImageLocation = string.Format("Items/Equipment/{0}/BasicGreave/BasicGreave", T1_Leg.fitsInSlot);
        T1_Leg.dropWeight = 1000;

        T2_Leg.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Leg;
        T2_Leg.itemName = "T2 Greave";
        T2_Leg.itemDescription = "T2 Greave";
        T2_Leg.itemImageLocation = string.Format("Items/Equipment/{0}/BasicGreave/BasicGreave", T2_Leg.fitsInSlot);
        T1_Leg.dropWeight = 1000;

        T3_Leg.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Leg;
        T3_Leg.itemName = "T3 Greave";
        T3_Leg.itemDescription = "T3 Greave";
        T3_Leg.itemImageLocation = string.Format("Items/Equipment/{0}/BasicGreave/BasicGreave", T3_Leg.fitsInSlot);
        T1_Leg.dropWeight = 1000;

        T4_Leg.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Leg;
        T4_Leg.itemName = "T4 Greave";
        T4_Leg.itemDescription = "T4 Greave";
        T4_Leg.itemImageLocation = string.Format("Items/Equipment/{0}/BasicGreave/BasicGreave", T4_Leg.fitsInSlot);
        T1_Leg.dropWeight = 1000;
    }

    public List<EquipmentInventoryItem> GetLegItems()
    {
        CreateAll();

        GetSomethingTypeLegs();

        return LegItems;
    }

    public List<EquipmentInventoryItem> GetSomethingTypeLegs()
    {
        LegItems.Add(T1_Leg);
        LegItems.Add(T2_Leg);
        LegItems.Add(T3_Leg);
        LegItems.Add(T4_Leg);

        return LegItems;
    }
}