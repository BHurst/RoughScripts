using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public ScriptableObject itemSO;
    [HideInInspector]
    public Item drop;
    public float dropRate;

    public WorldItem CreateDrop()
    {
        if(Random.Range(0f, 100f) <= dropRate)
        {
            drop = (Item)itemSO;
            WorldItem loot = new WorldItem();

            loot.inventoryItem = drop.inventoryItem.Clone();
            if (drop.inventoryItem.usable)
            {
                drop.SetSpecial();
                loot.inventoryItem.usableItem = drop.inventoryItem.usableItem;
            }
            return loot;
        }

        return null;
    }
}