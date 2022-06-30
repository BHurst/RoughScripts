using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextEquip : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane characterInventoryPane;

    private void Start()
    {
        if(characterInventoryPane == null)
            characterInventoryPane = GameObject.Find("CharacterInventoryCanvas").GetComponent<CharacterInventoryPane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var thing = PlayerCharacterUnit.player.charInventory.Inventory[UIManager.main.contextMenu.contextIndex];

        if (thing.itemType == InventoryItem.ItemType.Equipment)
        {
            PlayerCharacterUnit.player.unitEquipment.AddEquipment((EquipmentInventoryItem)thing);
            PlayerCharacterUnit.player.charInventory.Inventory.RemoveAt(UIManager.main.contextMenu.contextIndex);
            characterInventoryPane.RemoveInventorySlot(UIManager.main.contextMenu.contextIndex);
            characterInventoryPane.RefreshAllEquipmentUISlots();
            characterInventoryPane.ClearItemInfo();
            UIManager.main.contextMenu.HideMenu();
        }
    }
}