using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextSetQuick : MonoBehaviour, IPointerClickHandler
{
    public CharacterPanelScripts characterPanelScripts;
    public CharacterInventoryPane characterInventoryPane;

    private void Start()
    {
        if (characterInventoryPane == null)
            characterInventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        characterPanelScripts.quickItemSlot.SetQuickItem((ConsumableInventoryItem)GameWorldReferenceClass.GW_Player.charInventory.Inventory[characterInventoryPane.ContextIndex]);
        characterInventoryPane.CloseContext();
    }
}