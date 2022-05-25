using UnityEngine;
using System.Collections;

public class WorldItem : MonoBehaviour
{
    public InventoryItem inventoryItem;
    public WorldObjectTooltipTrigger tooltipInfo;

    private void Awake()
    {
        tooltipInfo = GetComponent<WorldObjectTooltipTrigger>();
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