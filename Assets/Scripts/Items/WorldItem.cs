using UnityEngine;
using System.Collections;

public class WorldItem : MonoBehaviour
{
    public ScriptableObject itemSO;
    [HideInInspector]
    public Item usableItem;
    public InventoryItem inventoryItem;

    private void Start()
    {
        if (usableItem != null)
        {
            inventoryItem = usableItem.inventoryItem.Clone();
            if(usableItem.inventoryItem.usable)
            {
                //inventoryItem.usableItem = usableItem.inventoryItem.usableItem;
            }
        }
    }
}