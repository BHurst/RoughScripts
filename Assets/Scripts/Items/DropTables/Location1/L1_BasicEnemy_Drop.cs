using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1_BasicEnemy_Drop : DropTable
{
    public L1_BasicEnemy_Drop()
    {
        chanceToRollOnTable = 100;
        drops = new List<ItemDrop>();

        drops.Add(new ItemDrop() { dropWeight = 1000f, itemDrop = ItemFactory.CreateRandomEquipment() });
        drops.Add(new ItemDrop() { dropWeight = 1000f, itemDrop = new Consumable_Item_NightShale() });
    }
}