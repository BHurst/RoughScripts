using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStats {

    public string itemName = "DEFAULT_ITEM";
    public string itemImageLocation = "Prefabs/Images/ItemPlaceholder";
    public string itemDescription = "A default item placeholder.";
    public int itemValue = 0;
    public bool usable = false;
    public int stackCount = 1;
    public int stackSize = 100;
    public bool stackable = false;
    public bool isEquipment = false;
    public RootEquipment equipment = new RootEquipment();

    public string LongHandStats()
    {
        string longText =
            itemName +
            "\nValue: " + itemValue;

        return longText;
    }
}