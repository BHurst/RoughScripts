using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SingleInventorySlotScript : MonoBehaviour, IPointerClickHandler
{
    public InventoryItem itemInSlot;
    public GameObject backImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            CharacterInventoryPane.DisplayItemInfo(itemInSlot);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(itemInSlot.slotEquippedIn != "None")
                GameWorldReferenceClass.GW_Player.doll.RemoveEquipment(itemInSlot);
            else
                GameWorldReferenceClass.GW_Player.doll.AddEquipment(itemInSlot);

            //GameWorldReferenceClass.GW_Player.charInventory.DropItem(itemInSlot, GameWorldReferenceClass.GW_Player);
            //Destroy(this.gameObject);
        }
    }
}