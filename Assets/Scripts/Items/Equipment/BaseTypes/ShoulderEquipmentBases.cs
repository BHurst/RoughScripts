using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderEquipmentBases
{
    List<EquipmentInventoryItem> ShoulderItems = new List<EquipmentInventoryItem>();

    EquipmentInventoryItem T1_Shoulder = new EquipmentInventoryItem();
    EquipmentInventoryItem T2_Shoulder = new EquipmentInventoryItem();
    EquipmentInventoryItem T3_Shoulder = new EquipmentInventoryItem();
    EquipmentInventoryItem T4_Shoulder = new EquipmentInventoryItem();

    public void CreateAll()
    {
        T1_Shoulder.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Shoulder;
        T1_Shoulder.itemName = "T1 Pauldron";
        T1_Shoulder.itemDescription = "T1 Pauldron";
        T1_Shoulder.itemImageLocation = string.Format("Items/Equipment/{0}/BasicPauldron/BasicPauldron", T1_Shoulder.fitsInSlot);
        T1_Shoulder.dropWeight = 1000;

        T2_Shoulder.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Shoulder;
        T2_Shoulder.itemName = "T2 Pauldron";
        T2_Shoulder.itemDescription = "T2 Pauldron";
        T2_Shoulder.itemImageLocation = string.Format("Items/Equipment/{0}/BasicPauldron/BasicPauldron", T2_Shoulder.fitsInSlot);
        T1_Shoulder.dropWeight = 1000;

        T3_Shoulder.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Shoulder;
        T3_Shoulder.itemName = "T3 Pauldron";
        T3_Shoulder.itemDescription = "T3 Pauldron";
        T3_Shoulder.itemImageLocation = string.Format("Items/Equipment/{0}/BasicPauldron/BasicPauldron", T3_Shoulder.fitsInSlot);
        T1_Shoulder.dropWeight = 1000;

        T4_Shoulder.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Shoulder;
        T4_Shoulder.itemName = "T4 Pauldron";
        T4_Shoulder.itemDescription = "T4 Pauldron";
        T4_Shoulder.itemImageLocation = string.Format("Items/Equipment/{0}/BasicPauldron/BasicPauldron", T4_Shoulder.fitsInSlot);
        T1_Shoulder.dropWeight = 1000;
    }

    public List<EquipmentInventoryItem> GetShoulderItems()
    {
        CreateAll();

        GetSomethingTypeShoulders();

        return ShoulderItems;
    }

    public List<EquipmentInventoryItem> GetSomethingTypeShoulders()
    {
        ShoulderItems.Add(T1_Shoulder);
        ShoulderItems.Add(T2_Shoulder);
        ShoulderItems.Add(T3_Shoulder);
        ShoulderItems.Add(T4_Shoulder);

        return ShoulderItems;
    }
}