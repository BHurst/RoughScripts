using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightFootSlotUI : MonoBehaviour
{
    public CharacterInventoryPane inventoryPane;

    public void OnEnable()
    {
        if (GameWorldReferenceClass.GW_Player.doll.Right_Foot_Slot.itemInSlot != null)
            GetComponent<Image>().sprite = Resources.Load<Sprite>(GameWorldReferenceClass.GW_Player.doll.Right_Foot_Slot.itemInSlot.itemImageLocation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            inventoryPane.DisplayItemInfo(GameWorldReferenceClass.GW_Player.doll.Right_Foot_Slot.itemInSlot);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }
}