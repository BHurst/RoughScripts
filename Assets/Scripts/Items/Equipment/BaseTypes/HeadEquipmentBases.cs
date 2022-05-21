using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadEquipmentBases
{
    List<EquipmentInventoryItem> HeadItems = new List<EquipmentInventoryItem>();

    EquipmentInventoryItem T1_Head = new EquipmentInventoryItem();
    EquipmentInventoryItem T2_Head = new EquipmentInventoryItem();
    EquipmentInventoryItem T3_Head = new EquipmentInventoryItem();
    EquipmentInventoryItem T4_Head = new EquipmentInventoryItem();

    public void CreateAll()
    {
        T1_Head.slotType = EquipmentSlot.SlotType.Head;
        T1_Head.itemName = "T1 Helmet";
        T1_Head.itemDescription = "T1 Helmet";
        T1_Head.itemImageLocation = string.Format("Items/Equipment/{0}/BasicHelm/BasicHelm", T1_Head.slotType);
        T1_Head.dropWeight = 1000;

        T2_Head.slotType = EquipmentSlot.SlotType.Head;
        T2_Head.itemName = "T2 Helmet";
        T2_Head.itemDescription = "T2 Helmet";
        T2_Head.itemImageLocation = string.Format("Items/Equipment/{0}/BasicHelm/BasicHelm", T2_Head.slotType);
        T1_Head.dropWeight = 1000;

        T3_Head.slotType = EquipmentSlot.SlotType.Head;
        T3_Head.itemName = "T3 Helmet";
        T3_Head.itemDescription = "T3 Helmet";
        T3_Head.itemImageLocation = string.Format("Items/Equipment/{0}/BasicHelm/BasicHelm", T3_Head.slotType);
        T1_Head.dropWeight = 1000;

        T4_Head.slotType = EquipmentSlot.SlotType.Head;
        T4_Head.itemName = "T4 Helmet";
        T4_Head.itemDescription = "T4 Helmet";
        T4_Head.itemImageLocation = string.Format("Items/Equipment/{0}/BasicHelm/BasicHelm", T4_Head.slotType);
        T1_Head.dropWeight = 1000;
    }

    public List<EquipmentInventoryItem> GetHeadItems()
    {
        CreateAll();

        GetSomethingTypeHeads();

        return HeadItems;
    }

    public List<EquipmentInventoryItem> GetSomethingTypeHeads()
    {
        HeadItems.Add(T1_Head);
        HeadItems.Add(T2_Head);
        HeadItems.Add(T3_Head);
        HeadItems.Add(T4_Head);

        return HeadItems;
    }
}