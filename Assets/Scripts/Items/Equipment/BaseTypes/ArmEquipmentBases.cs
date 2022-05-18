using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmEquipmentBases
{
    List<EquipmentInventoryItem> ArmItems = new List<EquipmentInventoryItem>();

    EquipmentInventoryItem T1_Arm = new EquipmentInventoryItem();
    EquipmentInventoryItem T2_Arm = new EquipmentInventoryItem();
    EquipmentInventoryItem T3_Arm = new EquipmentInventoryItem();
    EquipmentInventoryItem T4_Arm = new EquipmentInventoryItem();

    public void CreateAll()
    {
        T1_Arm.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Arm;
        T1_Arm.itemName = "T1 Vambrace";
        T1_Arm.itemDescription = "T1 Vambrace";
        T1_Arm.itemImageLocation = string.Format("Items/Equipment/{0}/BasicVambrace/BasicVambrace", T1_Arm.fitsInSlot);
        T1_Arm.dropWeight = 1000;

        T2_Arm.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Arm;
        T2_Arm.itemName = "T2 Vambrace";
        T2_Arm.itemDescription = "T2 Vambrace";
        T2_Arm.itemImageLocation = string.Format("Items/Equipment/{0}/BasicVambrace/BasicVambrace", T2_Arm.fitsInSlot);
        T1_Arm.dropWeight = 1000;

        T3_Arm.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Arm;
        T3_Arm.itemName = "T3 Vambrace";
        T3_Arm.itemDescription = "T3 Vambrace";
        T3_Arm.itemImageLocation = string.Format("Items/Equipment/{0}/BasicVambrace/BasicVambrace", T3_Arm.fitsInSlot);
        T1_Arm.dropWeight = 1000;

        T4_Arm.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Arm;
        T4_Arm.itemName = "T4 Vambrace";
        T4_Arm.itemDescription = "T4 Vambrace";
        T4_Arm.itemImageLocation = string.Format("Items/Equipment/{0}/BasicVambrace/BasicVambrace", T4_Arm.fitsInSlot);
        T1_Arm.dropWeight = 1000;
    }

    public List<EquipmentInventoryItem> GetArmItems()
    {
        CreateAll();

        GetSomethingTypeArms();

        return ArmItems;
    }

    public List<EquipmentInventoryItem> GetSomethingTypeArms()
    {
        ArmItems.Add(T1_Arm);
        ArmItems.Add(T2_Arm);
        ArmItems.Add(T3_Arm);
        ArmItems.Add(T4_Arm);

        return ArmItems;
    }
}