using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextDrop : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane characterInventoryPane;

    private void Start()
    {
        if (characterInventoryPane == null)
            characterInventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerCharacterUnit.player.charInventory.DropItem(UIManager.main.contextMenu.contextClicked.GetComponent<SingleInventorySlotScript>().itemInSlot, UIManager.main.contextMenu.contextIndex);
        UIManager.main.contextMenu.HideMenu();
    }
}