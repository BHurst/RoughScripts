using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsable
{
    //bool for "Should I be destroyed when I am out of charges?"
    public bool Use(RootUnit user, InventoryItem inventoryItem);
}