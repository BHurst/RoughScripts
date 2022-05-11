using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestEquipmentBases : MonoBehaviour
{
    List<EquipmentInventoryItem> ChestItems = new List<EquipmentInventoryItem>();

    EquipmentInventoryItem T1_Chest = new EquipmentInventoryItem();
    EquipmentInventoryItem T2_Chest = new EquipmentInventoryItem();
    EquipmentInventoryItem T3_Chest = new EquipmentInventoryItem();
    EquipmentInventoryItem T4_Chest = new EquipmentInventoryItem();

    public void CreateAll()
    {
        T1_Chest.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Chest;
        T1_Chest.itemName = "T1 Breastplate";
        T1_Chest.itemDescription = "T1 Breastplate";
        T1_Chest.itemImageLocation = string.Format("Items/Equipment/{0}/BasicBreastplate/BasicBreastplate", T1_Chest.fitsInSlot);
        T1_Chest.dropWeight = 1000;

        T2_Chest.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Chest;
        T2_Chest.itemName = "T2 Breastplate";
        T2_Chest.itemDescription = "T2 Breastplate";
        T2_Chest.itemImageLocation = string.Format("Items/Equipment/{0}/BasicBreastplate/BasicBreastplate", T2_Chest.fitsInSlot);
        T1_Chest.dropWeight = 1000;

        T3_Chest.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Chest;
        T3_Chest.itemName = "T3 Breastplate";
        T3_Chest.itemDescription = "T3 Breastplate";
        T3_Chest.itemImageLocation = string.Format("Items/Equipment/{0}/BasicBreastplate/BasicBreastplate", T3_Chest.fitsInSlot);
        T1_Chest.dropWeight = 1000;

        T4_Chest.fitsInSlot = EquipmentInventoryItem.EquipmentSlot.Chest;
        T4_Chest.itemName = "T4 Breastplate";
        T4_Chest.itemDescription = "T4 Breastplate";
        T4_Chest.itemImageLocation = string.Format("Items/Equipment/{0}/BasicBreastplate/BasicBreastplate", T4_Chest.fitsInSlot);
        T1_Chest.dropWeight = 1000;
    }

    public List<EquipmentInventoryItem> GetChestItems()
    {
        CreateAll();

        GetSomethingTypeChests();

        return ChestItems;
    }

    public List<EquipmentInventoryItem> GetSomethingTypeChests()
    {
        ChestItems.Add(T1_Chest);
        ChestItems.Add(T2_Chest);
        ChestItems.Add(T3_Chest);
        ChestItems.Add(T4_Chest);

        return ChestItems;
    }
}