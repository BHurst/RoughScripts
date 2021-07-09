using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LowerLeftArmSlotUI : MonoBehaviour
{
    public CharacterInventoryPane inventoryPane;

    public void OnEnable()
    {
        if (GameWorldReferenceClass.GW_Player.doll.Lower_Left_Arm_Slot.itemInSlot != null)
            GetComponent<Image>().sprite = Resources.Load<Sprite>(GameWorldReferenceClass.GW_Player.doll.Lower_Left_Arm_Slot.itemInSlot.itemImageLocation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            inventoryPane.DisplayItemInfo(GameWorldReferenceClass.GW_Player.doll.Lower_Left_Arm_Slot.itemInSlot);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }
}