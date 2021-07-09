using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public InventoryItem inventoryItem;

    public virtual bool Use(RootUnit user)
    {
        return false;
    }
    public virtual void SetSpecial()
    {

    }
}