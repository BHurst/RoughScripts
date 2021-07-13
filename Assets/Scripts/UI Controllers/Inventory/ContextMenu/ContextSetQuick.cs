using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextSetQuick : MonoBehaviour, IPointerClickHandler
{
    public CharacterPanelScripts characterPanelScripts;
    public CharacterInventoryPane characterInventoryPane;

    public void OnPointerClick(PointerEventData eventData)
    {
        characterPanelScripts.quickItemSlot.SetQuickItem(GameWorldReferenceClass.GW_Player.charInventory.Inventory[characterInventoryPane.ContextIndex]);
        characterInventoryPane.CloseContext();
    }
}