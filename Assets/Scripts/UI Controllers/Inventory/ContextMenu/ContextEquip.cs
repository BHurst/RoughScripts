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
        var thing = GameWorldReferenceClass.GW_Player.charInventory.Inventory[characterInventoryPane.ContextIndex];

        if (thing.itemType == InventoryItem.ItemType.Equipment)
        {
            GameWorldReferenceClass.GW_Player.unitEquipment.AddEquipment((EquipmentInventoryItem)thing);
            GameWorldReferenceClass.GW_Player.charInventory.Inventory.RemoveAt(characterInventoryPane.ContextIndex);
            characterInventoryPane.RemoveInventorySlot(characterInventoryPane.ContextIndex);
            characterInventoryPane.RefreshAllEquipmentUISlots();
            characterInventoryPane.ClearItemInfo();
            characterInventoryPane.CloseContext();
        }
    }
}