using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;

public class WorldItem : MonoBehaviour
{
    public string itemToLoadType = "";
    public InventoryItem inventoryItem;
    public WorldObjectTooltipTrigger tooltipInfo;

    private void Awake()
    {
        tooltipInfo = GetComponent<WorldObjectTooltipTrigger>();
    }

    private void Start()
    {
        if (!string.IsNullOrEmpty(itemToLoadType) && itemToLoadType != "None")
        {
            InventoryItem instance = (InventoryItem)Activator.CreateInstance(Type.GetType(itemToLoadType));
            inventoryItem = instance;
            
        }

        if(inventoryItem != null)
            SetTooltipInfo();
    }

    public void SetTooltipInfo()
    {
        tooltipInfo.headerContent = inventoryItem.itemName;
        tooltipInfo.shorthandContent = inventoryItem.maxStackSize > 1 ? inventoryItem.currentStackSize + "/" + inventoryItem.maxStackSize : "";
        tooltipInfo.bodyContent = inventoryItem.itemDescription;
        tooltipInfo.tertiaryContent = "";
    }
}