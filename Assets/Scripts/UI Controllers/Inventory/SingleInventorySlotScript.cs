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
        inventoryPane = GameObject.Find("CharacterInventory").GetComponent<CharacterInventoryPane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            inventoryPane.DisplayItemInfo(GameWorldReferenceClass.GW_Player.charInventory.Inventory[inventoryIndex]);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            inventoryPane.DisplayContextMenu(GameWorldReferenceClass.GW_Player.charInventory.Inventory[inventoryIndex], inventoryIndex);
        }
    }
}