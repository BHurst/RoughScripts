using UnityEngine;
using System.Collections;

public class Consumable : InventoryItem {

    public string useType = "";


    public void ItemUse()
    {
        iStats.stackCount--;
        if(iStats.stackCount == 0)
        {
            RemoveItem();
        }
    }

}