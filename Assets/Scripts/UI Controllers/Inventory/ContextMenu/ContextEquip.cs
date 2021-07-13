using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextEquip : MonoBehaviour, IPointerClickHandler
{
    public CharacterInventoryPane characterInventoryPane;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameWorldReferenceClass.GW_Player.charInventory.Inventory[characterInventoryPane.ContextIndex].itemType == ItemType.Equipment)
        {
            GameWorldReferenceClass.GW_Player.doll.AddEquipment((EquipmentInventoryItem)GameWorldReferenceClass.GW_Player.charInventory.Inventory[characterInventoryPane.ContextIndex]);
            GameWorldReferenceClass.GW_Player.charInventory.Inventory.RemoveAt(characterInventoryPane.ContextIndex);
            //inventoryPane.DisplayCharacterInventory();
            characterInventoryPane.RemoveInventorySlot(characterInventoryPane.ContextIndex);
            characterInventoryPane.CloseContext();
        }
    }
}