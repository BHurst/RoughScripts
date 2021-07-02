using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SingleInventorySlotScript : MonoBehaviour, IPointerClickHandler
{
    public Item itemInSlot;
    public GameObject backImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            CharacterInventoryPane.DisplayItemInfo(itemInSlot);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            
        }
    }
}