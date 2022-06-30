using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextSetQuick : MonoBehaviour, IPointerClickHandler
{
    public UIManager characterPanelScripts;
    public CharacterInventoryPane characterInventoryPane;

    private void Start()
    {
        if (characterInventoryPane == null)
            characterInventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        characterPanelScripts.quickItemSlot.SetQuickItem((ConsumableInventoryItem)PlayerCharacterUnit.player.charInventory.Inventory[UIManager.main.contextMenu.contextIndex]);
        UIManager.main.contextMenu.HideMenu();
    }
}