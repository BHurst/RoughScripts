using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SingleInventorySlotScript : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane inventoryPane;
    public int inventoryIndex;

    private void Start()
    {
        inventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            inventoryPane.DisplayItemInfo(PlayerCharacterUnit.player.charInventory.Inventory[inventoryIndex]);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            inventoryPane.contextClicked = eventData.pointerPress.gameObject;
            inventoryPane.DisplayContextMenu(PlayerCharacterUnit.player.charInventory.Inventory[inventoryIndex], inventoryIndex);
        }
    }
}