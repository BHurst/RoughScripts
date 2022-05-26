using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    RootCharacter unit;
    public List<DropTable> dropTables = new List<DropTable>();

    private void Start()
    {
        unit = GetComponent<RootCharacter>();
    }

    public List<InventoryItem> CreateDrop()
    {
        List<InventoryItem> loot = new List<InventoryItem>();

        foreach (var table in dropTables)
        {
            if (Random.Range(0, 101) <= table.chanceToRollOnTable)
            {
                InventoryItem newLoot = new InventoryItem();
                newLoot = RollOnTable(table);
                loot.Add(newLoot);
            }
        }

        return loot;
    }

    public InventoryItem RollOnTable(DropTable table)
    {
        InventoryItem loot = new InventoryItem();
        float randWholePool = 0;
        float randIncrementPool = 0;

        foreach (var item in table.drops)
        {
            randWholePool += item.dropWeight;
        }

        float randPick = Random.Range(0, randWholePool);

        foreach (var item in table.drops)
        {
            if (randPick <= item.dropWeight + randIncrementPool)
            {
                loot = item.itemDrop;
                break;
            }
            else
                randIncrementPool += item.dropWeight;
        }

        return loot;
    }
}