using UnityEngine;
using System.Collections;

[System.Serializable]
public class InventoryItem {

    public ItemStats iStats = new ItemStats();
    public string slotEquippedIn = "None";

    public void RemoveItem()
    {

    }

    public int StackIncrease(int amount)
    {
        int tempReturn = 0;
        if ((iStats.stackCount + amount) > iStats.stackSize)
        {
            tempReturn = (iStats.stackCount + amount) % iStats.stackSize;
            iStats.stackCount = iStats.stackSize;
            return tempReturn;
        }
        else
        {
            iStats.stackCount += amount;
            return tempReturn;
        }
    }
}
