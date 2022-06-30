using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreFrontData
{
    public bool allowBeingSoldTo = true;
    public bool hasInventoryToSell = true;
    public List<LineItem> lineItems = new List<LineItem>() { 
    new LineItem(){ item = new Consumable_Item_NightShale(), cost = 5, currentStock = 5, maxStock = 5 }
    };
}

public class LineItem
{
    public InventoryItem item;
    public int cost = 0;
    public int currentStock = 0;
    public int maxStock = 1;
}