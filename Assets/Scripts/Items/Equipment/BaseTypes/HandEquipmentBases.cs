using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandEquipmentBases
{
    List<EquipmentInventoryItem> HandItems = new List<EquipmentInventoryItem>();

    EquipmentInventoryItem T1_Hand = new EquipmentInventoryItem();
    EquipmentInventoryItem T2_Hand = new EquipmentInventoryItem();
    EquipmentInventoryItem T3_Hand = new EquipmentInventoryItem();
    EquipmentInventoryItem T4_Hand = new EquipmentInventoryItem();

    public void CreateAll()
    {
        T1_Hand.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Hand;
        T1_Hand.itemName = "T1 Gauntlet";
        T1_Hand.itemDescription = "T1 Gauntlet";
        T1_Hand.itemImageLocation = string.Format("Items/Equipment/{0}/BasicGauntlet/BasicGauntlet", T1_Hand.fitsInSlot);
        T1_Hand.dropWeight = 1000;

        T2_Hand.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Hand;
        T2_Hand.itemName = "T2 Gauntlet";
        T2_Hand.itemDescription = "T2 Gauntlet";
        T2_Hand.itemImageLocation = string.Format("Items/Equipment/{0}/BasicGauntlet/BasicGauntlet", T2_Hand.fitsInSlot);
        T1_Hand.dropWeight = 1000;

        T3_Hand.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Hand;
        T3_Hand.itemName = "T3 Gauntlet";
        T3_Hand.itemDescription = "T3 Gauntlet";
        T3_Hand.itemImageLocation = string.Format("Items/Equipment/{0}/BasicGauntlet/BasicGauntlet", T3_Hand.fitsInSlot);
        T1_Hand.dropWeight = 1000;

        T4_Hand.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Hand;
        T4_Hand.itemName = "T4 Gauntlet";
        T4_Hand.itemDescription = "T4 Gauntlet";
        T4_Hand.itemImageLocation = string.Format("Items/Equipment/{0}/BasicGauntlet/BasicGauntlet", T4_Hand.fitsInSlot);
        T1_Hand.dropWeight = 1000;
    }

    public List<EquipmentInventoryItem> GetHandItems()
    {
        CreateAll();

        GetSomethingTypeHands();

        return HandItems;
    }

    public List<EquipmentInventoryItem> GetSomethingTypeHands()
    {
        HandItems.Add(T1_Hand);
        HandItems.Add(T2_Hand);
        HandItems.Add(T3_Hand);
        HandItems.Add(T4_Hand);

        return HandItems;
    }
}