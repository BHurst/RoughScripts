using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlotScript : MonoBehaviour, IPointerClickHandler
{
    InventoryItem itemInSlot = new InventoryItem();

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            CharacterInventoryPane.DisplayItemInfo(itemInSlot);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(itemInSlot.iStats.itemName != "DEFAULT_ITEM")
            {
                GameWorldReferenceClass.GW_Player.doll.RemoveEquipment(itemInSlot);
                foreach(var thing in GameWorldReferenceClass.GW_Player.charInventory.Inventory)
                {

                }
            }
        }
    }
}