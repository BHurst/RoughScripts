using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConsumableInventoryItem : InventoryItem
{
    public int currentUses = 0;
    public int maxUses = 0;
}