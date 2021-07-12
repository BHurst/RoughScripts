using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public List<LootBracket> brackets;
    float roll;

    public List<WorldItem> CreateDrop()
    {
        List<WorldItem> loot = new List<WorldItem>();
        for (int i = 0; i < brackets.Count; i++)
        {
            roll = Random.Range(0f, 100f);
            if (roll <= brackets[i].chance)
            {
                Item drop = (Item)brackets[i].loot[Random.Range(0, brackets[i].loot.Count-1)];

                WorldItem worldItem = new WorldItem();
                worldItem.inventoryItem = drop.inventoryItem.Clone();
                if (drop.inventoryItem.usable)
                {
                    drop.SetSpecial();
                    worldItem.inventoryItem.usableItem = drop.inventoryItem.usableItem;
                }
                loot.Add(worldItem);
            }
        }
        return loot;
    }
}