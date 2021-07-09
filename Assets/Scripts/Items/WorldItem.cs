using UnityEngine;
using System.Collections;

public class WorldItem : MonoBehaviour
{
    public ScriptableObject itemSO;
    [HideInInspector]
    public Item itemForUse;
    public InventoryItem inventoryItem;

    private void Start()
    {
        itemForUse = (Item)itemSO;
        if (itemForUse != null)
        {
            inventoryItem = itemForUse.inventoryItem.Clone();
            if(itemForUse.inventoryItem.usable)
            {
                itemForUse.SetSpecial();
                inventoryItem.usableItem = itemForUse.inventoryItem.usableItem;
            }
        }
    }
}