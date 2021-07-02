using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlotScript : MonoBehaviour, IPointerClickHandler
{
    EquipmentSlotName eSlotName;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            CharacterInventoryPane.DisplayItemInfo((Item)GameWorldReferenceClass.GW_Player.doll.GetType().GetField(eSlotName.ToString()).GetValue(GameWorldReferenceClass.GW_Player.doll));
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            bool valid = (Item)GameWorldReferenceClass.GW_Player.doll.GetType().GetField(eSlotName.ToString()).GetValue(GameWorldReferenceClass.GW_Player.doll); 
            if (valid)
            {
                GameWorldReferenceClass.GW_Player.doll.RemoveEquipment(eSlotName);
                foreach(var thing in GameWorldReferenceClass.GW_Player.charInventory.Inventory)
                {

                }
            }
        }
    }
}